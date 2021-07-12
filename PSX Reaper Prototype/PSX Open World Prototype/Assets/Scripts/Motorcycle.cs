using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motorcycle : Vehicle
{
    private Transform bikeBody;
    private WheelGrounding frontWheel;
    private WheelGrounding rearWheel;

    //properties
    public bool gas = false;
    public bool brake = false;
    public bool fbrake = false;
    public bool drift = false;
    private int[] turnVec = {0,0};          //l,r
    private int[] wheelieVec = {0,0};      //u,d
    private float horInput;
    private float driftLock = 0.0f;

    //motorcycle stats
    public float maxSpeed = 30.0f;
    public float accelRate = 15.0f;      //m/s^2
    public float brakeRate = 15.0f;
    public float turn = 140.0f;           //rotation amount higher = tighter turn radius
    public float maxLean = 20.0f;
    public float maxWheelie = 45.0f;

    //DriftController.cs physics stats
    public float GripX = 12.0f;         //sideways friction  (higher -> quicker stop)
    public float GripZ = 5.0f;          //forward friction (higher -> harder to drift) 
    private float RotVel = 0.7f;        //ratio of forward velocity transferred on rotation
    private float MinRotSpeed = 0.25f;
    private float MaxRotSpeed = 5f;
    public AnimationCurve SlipL;
    public AnimationCurve SlipU;
    private float SlipMod = 5.0f;      //higher -> harder to enter drift
    float isRight = 1.0f;
    float isForward = 1.0f;                 
    private bool isRotating = false;        //in rotation
    public bool inSlip = false;            //vehicle is slipping 
    Vector3 vel = Vector3.zero;
    public Vector3 pvel = Vector3.zero;

    float accel;
    float rot;
    float gripX;
    float gripZ;
    float rotVel;
    float slip;

    private Quaternion upright;         //save upright rotation of the bike

    //controls
    Control_Map cmap;

    //input controls
    void Awake(){
        cmap = new Control_Map();

        //bike movement (lean)
        cmap.PSX_Controller.MoveLeft.performed += ctx => {turnVec[0] = 1;};
        cmap.PSX_Controller.MoveRight.performed += ctx => {turnVec[1] = 1;};
        cmap.PSX_Controller.MoveLeft.canceled += ctx => {turnVec[0] = 0;};
        cmap.PSX_Controller.MoveRight.canceled += ctx =>{turnVec[1] = 0;};

        //cmap.PSX_Controller.MoveDown.performed += ctx => {backup = true;};
        //cmap.PSX_Controller.MoveDown.canceled += ctx => {backup = false;};

        cmap.PSX_Controller.MoveUp.performed += ctx => {wheelieVec[0] = 1;};
        cmap.PSX_Controller.MoveDown.performed += ctx => {wheelieVec[1] = 1;};
        cmap.PSX_Controller.MoveUp.canceled += ctx => {wheelieVec[0] = 0;};
        cmap.PSX_Controller.MoveDown.canceled += ctx =>{wheelieVec[1] = 0;};

        //gas/brake
        cmap.PSX_Controller.Jump_Fly.performed += ctx => {gas = true;};
        cmap.PSX_Controller.Jump_Fly.canceled += ctx => {gas = false;};

        cmap.PSX_Controller.Sword.performed += ctx => {brake = true;};
        cmap.PSX_Controller.Sword.canceled += ctx => {brake = false;};

        cmap.PSX_Controller.Interact.performed += ctx => {fbrake = true;};
        cmap.PSX_Controller.Interact.canceled += ctx => {fbrake = false;};

        //drift
        cmap.PSX_Controller.CamLeft.performed += ctx => {drift = true;};
        cmap.PSX_Controller.CamLeft.canceled += ctx => {drift = false;};
        cmap.PSX_Controller.CamRight.performed += ctx => {drift = true;};
        cmap.PSX_Controller.CamRight.canceled += ctx => {drift = false;};

    }
    void OnEnable(){
        cmap.PSX_Controller.Enable();
    }
    void OnDisable(){
        cmap.PSX_Controller.Disable();
    }

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
        bikeBody = transform.Find("Body");
        upright = transform.rotation;
        seat = bikeBody.Find("Seat");

        Transform wheels = transform.Find("Wheels");
        frontWheel = wheels.Find("FrontWheel").GetComponent<WheelGrounding>();
        rearWheel = wheels.Find("RearWheel").GetComponent<WheelGrounding>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        //only perform if has driver
        if(rider != null){
            //reset everything
            accel = accelRate;
            rot = turn;
            gripX = GripX;
            gripZ = GripZ;
            rotVel = RotVel;
            rb.angularDrag = 5.0f;

            accel = accel * Mathf.Cos(transform.eulerAngles.x * Mathf.Deg2Rad);
            accel = accel > 0f ? accel : 0f;
            gripX = gripX * Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad);
            gripX = gripX > 0f ? gripX : 0f;
            gripZ = gripZ * Mathf.Cos(transform.eulerAngles.x * Mathf.Deg2Rad);
            gripZ = gripZ > 0f ? gripZ : 0f;

            //freefallin
            if(!rearWheel.isGrounded && !frontWheel.isGrounded){
                accel = 0f;
                rot = 0f;
                gripX = 0f;
                gripZ = 0f;
                rb.angularDrag = 1.0f;
            }

            //turning if moving
            if(pvel.magnitude < MinRotSpeed){
                rot = 0f;
            }else{
                rot = pvel.magnitude / MaxRotSpeed * rot;
            }

            //max out rotation
            if(rot > turn) rot = turn;

            //check if within the slip range
            if(!inSlip){
                slip = this.SlipL.Evaluate(Mathf.Abs(pvel.x)/SlipMod);
                if(slip == 1f) inSlip = true;
            }else{
                slip = this.SlipU.Evaluate(Mathf.Abs(pvel.x)/SlipMod);
                if(slip == 0f) inSlip = false;
            }

            rot *= (1f - 3.0f*slip);
            rotVel *= (1f - slip);



            GetInput();
            HandleMotor();
            HandleSteering();
            Lean();
            //Wheelie();



            vel = transform.InverseTransformDirection(rb.velocity);
            if(isRotating){
                vel = vel * (1 - rotVel) + pvel * rotVel;
            }

            //apply velocities
            isRight = vel.x > 0f ? 1f : -1f;
            vel.x -= isRight * gripX * Time.deltaTime;
            if(vel.x * isRight < 0f) vel.x = 0f;

            isForward = vel.z > 0f ? 1f : -1f;
            vel.z -= isForward * gripZ * Time.deltaTime;
            if(vel.z * isForward < 0f) vel.z = 0f;

            //top speed
            if(vel.z > maxSpeed) {
                vel.z = maxSpeed;
            }else if (vel.z < -maxSpeed){
                vel.z = -maxSpeed;
            }

            rb.velocity = transform.TransformDirection(vel);


            //keep upright
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);

            //keep player in the seat
            rider.transform.eulerAngles = seat.eulerAngles;


            //Debug.Log("X: " + gripX.ToString() + " | Z: " + gripZ.ToString() + " | Slip: " + slip + " | PVEL.X: " + Mathf.Abs(pvel.x));
        }
    }

    //slowly lean the bike when turning
    private void Lean(){
        float leanSpeed = 5.0f;
        float toPos = 0.0f;
        if(!drift){
            if(turnVec[0] == 1){
                toPos = 1.0f;
            }else if(turnVec[1] == 1){
                toPos = -1.0f;
            }
        }else{
            if(driftLock == -1){
                toPos = 2f;
            }else if(driftLock == 1){
                toPos = -2f;
            }
        }
        bikeBody.localRotation = Quaternion.Slerp(bikeBody.localRotation, Quaternion.Euler(0,0,toPos*maxLean), Time.fixedDeltaTime*leanSpeed);
    }

    //allow wheelies
    private void Wheelie(){
        float leanSpeed = 2.0f;
        float toPos = 0.0f;
        if(wheelieVec[0] == 1){
            toPos = 1.0f;
        }else if(wheelieVec[1] == 1){
            toPos = -1.0f;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(toPos*maxWheelie,0,0), Time.fixedDeltaTime*leanSpeed);
    }

    //handle controller input for vehicle
    private void GetInput(){
        //left/right
        horInput = 0.0f;
        if(turnVec[0] == 1){
            horInput = -1.0f;
        }else if(turnVec[1] == 1){
            horInput = 1.0f;
        }

        //gas
        // vertInput = 0.0f;
        // if(gas){
        //     vertInput = 1.0f;
        // }
        // else if(backup){
        //     vertInput = -1.0f;
        // }
    }

    private void HandleMotor(){
        //gas
        if(gas && Mathf.Abs(rb.velocity.magnitude) < maxSpeed){
            rb.velocity += transform.forward * accelRate * Time.deltaTime;
            gripZ = 0f;     //need this or vehicle won't move
        }
        //brake
        if(brake && rearWheel.isGrounded){
            rb.velocity -= transform.forward * brakeRate * Time.deltaTime;
        }
        if(fbrake && frontWheel.isGrounded){
            rb.velocity -= transform.forward * brakeRate * Time.deltaTime;
        }

        //drift
        if(drift && frontWheel.isGrounded && rearWheel.isGrounded){
            gripX = 20f;
            gripZ = 2f;
        }

        isRotating = false;

        pvel = transform.InverseTransformDirection(rb.velocity);

    }

    private void HandleSteering(){
        //steering
        // if(turnVec[0] == 1){
        //     transform.Rotate(Vector3.up*-turn);
        // }else if(turnVec[1] == 1){
        //     transform.Rotate(Vector3.up*turn);
        // }
        if((horInput == -1 || horInput == 1) && frontWheel.isGrounded && !drift){
            float d = (pvel.z < 0) ? -1 : 1;
            Vector3 drot = Vector3.zero;
            drot.y = d*horInput*rot*Time.deltaTime;
            Debug.Log("normal: " + drot.y);
            transform.rotation *= Quaternion.AngleAxis(drot.y, transform.up);
            isRotating = true;
            driftLock = horInput;
        }else if(drift && frontWheel.isGrounded){
            float d = (pvel.z < 0) ? -1 : 1;
            Vector3 drot = Vector3.zero;
            drot.y = d*(driftLock)*(rot - (driftLock*horInput*(rot/2.0f)))*Time.deltaTime;
            //drot.y = d*(driftLock)*(rot)*Time.deltaTime;
            Debug.Log("drift: " + drot.y);
            transform.rotation *= Quaternion.AngleAxis(drot.y, transform.up);
            isRotating = true;
        }

    }

}
