using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//from tutorial: https://www.youtube.com/watch?v=Z4HA8zJhGEk&ab_channel=GameDevChef

public class AdvancedMotorcycle : Vehicle
{
    // private Rigidbody rb;
    // private Transform seat;
    private Transform bikeBody;

    //properties
    // [HideInInspector] public GameObject rider;
    // public bool driving = false;

    public bool gas = false;
    public bool brake = false;
    public bool fbrake = false;
    public bool backup = false;
    private int[] turnVec = {0,0};      //l,r
    private int[] leanVec = {0,0};      //u,d
    private float horInput;
    private float vertInput;

    private float curSteerAngle;
    private float curBrakeForce;
    private float medRPM;
    private float speed;

    //mod fields
    [SerializeField] private float motorForce;
    [SerializeField] private float brakeForce;
    [SerializeField] private float maxSteeringAngle;

    [SerializeField] public WheelCollider frontWheelCol;
    [SerializeField] public WheelCollider rearWheelCol;
    [SerializeField] private Transform frontWheelTrans;
    [SerializeField] private Transform rearWheelTrans;

    //controls
    Control_Map cmap;

    //input controls
    void Awake(){
        cmap = new Control_Map();
        //cmap.PSX_Controller.Jump_Fly.performed += ctx => {Debug.Log("MEH");};

        //bike movement (lean)
        cmap.PSX_Controller.MoveLeft.performed += ctx => {turnVec[0] = 1;};
        cmap.PSX_Controller.MoveRight.performed += ctx => {turnVec[1] = 1;};
        cmap.PSX_Controller.MoveLeft.canceled += ctx => {turnVec[0] = 0;};
        cmap.PSX_Controller.MoveRight.canceled += ctx =>{turnVec[1] = 0;};

        cmap.PSX_Controller.MoveDown.performed += ctx => {backup = true;};
        cmap.PSX_Controller.MoveDown.canceled += ctx => {backup = false;};

        // cmap.PSX_Controller.MoveUp.performed += ctx => {leanVec[0] = 1;};
        // cmap.PSX_Controller.MoveDown.performed += ctx => {leanVec[1] = 1;};
        // cmap.PSX_Controller.MoveUp.canceled += ctx => {leanVec[0] = 0;};
        // cmap.PSX_Controller.MoveDown.canceled += ctx =>{leanVec[1] = 0;};

        //gas/brake
        cmap.PSX_Controller.Jump_Fly.performed += ctx => {gas = true;};
        cmap.PSX_Controller.Jump_Fly.canceled += ctx => {gas = false;};

        cmap.PSX_Controller.CamLeft.performed += ctx => {brake = true;};
        cmap.PSX_Controller.CamLeft.canceled += ctx => {brake = false;};

        cmap.PSX_Controller.CamRight.performed += ctx => {fbrake = true;};
        cmap.PSX_Controller.CamRight.canceled += ctx => {fbrake = false;};

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
        seat = bikeBody.Find("Seat");

         //centerOfMass
        GameObject com = new GameObject ("centerOfmass");
        com.transform.parent = transform;
        com.transform.localPosition = new Vector3 (0.0f, -0.3f, 0.0f);
        rb.centerOfMass = transform.InverseTransformPoint(com.transform.position);
    }

    //main loop
    private void FixedUpdate(){
        if(rider != null){
            HandleMotor();
            HandleSteering();
            UpdateWheels();
            GetInput();

            //lean
            rider.transform.eulerAngles = seat.eulerAngles;
            Quaternion bodyRotation = transform.rotation * Quaternion.Euler(0f, 0f, -frontWheelCol.steerAngle/2);
            bikeBody.rotation = Quaternion.Lerp(bikeBody.rotation, bodyRotation, 0.1f);
           
        }
    }

    //////////////    CONTROLS     //////////////

    private void HandleMotor(){

        //frontWheelCol.motorTorque = vertInput * motorForce;
        curBrakeForce = (brake || fbrake) ? brakeForce*rb.mass : 0.0f;
        ApplyBrakes();

        medRPM = (frontWheelCol.rpm + rearWheelCol.rpm) / 2;
        speed = rb.velocity.magnitude;
        //rearWheelCol.motorTorque = vertInput * rb.mass * motorForce;
 
        //motorTorque
        if (vertInput < 0) {
            rearWheelCol.motorTorque = vertInput * rb.mass * motorForce/3;
        } else {
            rearWheelCol.motorTorque = vertInput * rb.mass * motorForce;
        }
 
        //cap speed
        if(Mathf.Abs(rearWheelCol.rpm) > 750){
            rearWheelCol.motorTorque = 0.0f;
            rearWheelCol.brakeTorque = rb.mass * 5;
        }
        // //
        // if (speed < 1.0f && Mathf.Abs (vertInput) < 0.1f) {
        //     rearWheelCol.brakeTorque = frontWheelCol.brakeTorque = rb.mass * 2.0f;
        // } else {
        //     rearWheelCol.brakeTorque = frontWheelCol.brakeTorque = 0.0f;
        // }
        //
        
        Stabilizer();
        
    }

    private void Stabilizer(){
        Vector3 axisFromRotate = Vector3.Cross (transform.up, Vector3.up);
        Vector3 torqueForce = axisFromRotate.normalized * axisFromRotate.magnitude * 50;
        torqueForce.x = torqueForce.x * 0.4f;
        torqueForce -= rb.angularVelocity;
        rb.AddTorque (torqueForce * rb.mass * 0.02f, ForceMode.Impulse);
 
        float rpmSign = Mathf.Sign (medRPM) * 0.02f;
        if (speed > 1.0f && frontWheelCol.isGrounded && rearWheelCol.isGrounded) {
            rb.angularVelocity += new Vector3 (0, horInput * rpmSign, 0);
        }
    }

    private void ApplyBrakes(){
        //frontWheelCol.brakeTorque = curBrakeForce;
        WheelFrictionCurve ff = rearWheelCol.forwardFriction;
        WheelFrictionCurve sf = rearWheelCol.sidewaysFriction;

        frontWheelCol.brakeTorque = (fbrake ? curBrakeForce : 0.0f);
        rearWheelCol.brakeTorque = (brake ? curBrakeForce : 0.0f);

        float velocity = 0.0f;

        //ff.stiffness = (brake) ? Mathf.SmoothDamp(ff.stiffness, 0.3f, ref velocity, Time.deltaTime*1): 1f;
        sf.stiffness = (brake) ? Mathf.SmoothDamp(sf.stiffness, 0.7f, ref velocity, Time.deltaTime*1): 1f;

        rearWheelCol.forwardFriction = ff;
        rearWheelCol.sidewaysFriction = sf;
    }

    private void HandleSteering(){
        // curSteerAngle = maxSteeringAngle * horInput;
        // frontWheelCol.steerAngle = curSteerAngle;

        //steerAngle
        float nextAngle = horInput * maxSteeringAngle;
        frontWheelCol.steerAngle = Mathf.Lerp (frontWheelCol.steerAngle, nextAngle, 0.125f);
    }

    private void UpdateWheels(){
        UpdateSingleWheel(frontWheelCol,frontWheelTrans);
        UpdateSingleWheel(rearWheelCol,rearWheelTrans);
    }

    private void UpdateSingleWheel(WheelCollider wc, Transform t){
        Vector3 pos;
        Quaternion rot;
        wc.GetWorldPose(out pos, out rot);
        t.rotation = rot;
        t.position = pos;
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
        vertInput = 0.0f;
        if(gas){
            vertInput = 1.0f;
        }else if(backup){
            vertInput = -1.0f;
        }
    }


    /////////////    ENABLE RIDER   ///////////////

    //attach a passenger
    // public void Mount(GameObject c){
    //     if(rider == null){
    //         rider = c;
    //         driving = true;
    //         c.transform.position = seat.transform.position;
    //         c.transform.parent = seat;
    //         transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,transform.eulerAngles.z);

    //         Debug.Log("ride on shooting star!");
    //         rb.velocity = Vector3.zero;
    //     }
    // }

    // //remove the passenger
    // public void Dismount(){
    //     if(driving && rider != null){
    //         rider.transform.parent = null;
    //         rider.transform.position = transform.Find("Dismount").transform.position;
    //         rider.transform.GetComponent<Collider>().enabled = true;
    //         rider.transform.GetComponent<CharacterController>().enabled = true;
    //         driving = false;
            
    //         Debug.Log("bike machine broke");

    //         FullDismount();
    //     }
    // }

    // //unparent the passenger
    // public void FullDismount(){
    //     if(!driving && rider != null){
    //         rider.GetComponent<PSX_Movement>().driving = false;
    //         rider.GetComponent<PSX_Movement>().CamToPlayer();
    //         rider = null;

    //         Debug.Log("deadass");
    //     }
        
    // }
}
