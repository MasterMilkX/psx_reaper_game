using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PSX_Movement : MonoBehaviour
{

    //controls
    Control_Map cmap;
    private Wing wingAnimate;
    private Sword sword;

    //character controls
    //private SpriteAnimator sprAnim;
    private Rigidbody rb;
    private CharacterController cc;

    //properties
    public int maxHealth = 100;
    public int curHealth = 100;

    //interactions
    public Interactor inter;
    public bool driving = false;
    public bool canDrive = false;
    public Transform curVehicle;
    public bool usedSword = false;

    //z-targeting
    private Ztarget ztScript;
    public bool ztargeting = false;
    public Transform curTarget = null;

    //camera and rotation
    public Transform cam;
    public float rotY = 0.0f;

    //sprite directiomn
    public string dir = "";
    public string sec_dir = "";
    private int horDir = 0;
    private int verDir = 0;
    private int[] axisActive = {0,0,0,0};

    
    public float camSpeed = 1.0f;
    private int turnCam = 0;
    private Vector3 camOffR = new Vector3(0,2.3f,-6.89f);
    private Vector3 camOffP = new Vector3(0,1.33f,0);
    private Vector3 camOffR_fall = new Vector3(0,2.33f,-4.6f);

    private Vector3 camOffR_moto = new Vector3(0,2.79f,-7.9f);
    private Vector3 camOffP_moto = new Vector3(0,2.35f,0);

    //speed modifiers
    public float moveSpeed = 2.0f;

    //jump/fly modifiers
    private float velY;
    public float jumpForce = 5.0f;
    public float gravityMod = 0.5f;
    public int maxStamina = 100;
    public int curStamina = 100;
    public int staminaDepl = 10;
    public float terminalVel = 30.0f;
    private bool fallDmg = false;
    private bool jumper = false;

    //debugger pane
    public Text debugTextUI;
    private string debugTxt;

    //input controls
    void Awake(){
        cmap = new Control_Map();
        //cmap.PSX_Controller.Jump_Fly.performed += ctx => {Debug.Log("MEH");};

        //player movement
        cmap.PSX_Controller.MoveLeft.performed += ctx => {horDir = -1;axisActive[2] = 1;};
        cmap.PSX_Controller.MoveRight.performed += ctx => {horDir = 1;axisActive[3] = 1;};
        cmap.PSX_Controller.MoveUp.performed += ctx => {verDir = 1;axisActive[0] = 1;};
        cmap.PSX_Controller.MoveDown.performed += ctx => {verDir = -1;axisActive[1] = 1;};
        cmap.PSX_Controller.MoveLeft.canceled += ctx => {axisActive[2] = 0;};
        cmap.PSX_Controller.MoveRight.canceled += ctx =>{axisActive[3] = 0;};
        cmap.PSX_Controller.MoveUp.canceled += ctx => {axisActive[0] = 0;};
        cmap.PSX_Controller.MoveDown.canceled += ctx => {axisActive[1] = 0;};

        //z-targeting
        cmap.PSX_Controller.CamRight.performed += ctx => ToggleZTarget();
        cmap.PSX_Controller.CamRight.canceled += ctx => {};

        //camera movement
        cmap.PSX_Controller.CamLeft2.performed += ctx => {turnCam = -1;};
        cmap.PSX_Controller.CamRight2.performed += ctx => {turnCam = 1;};
        cmap.PSX_Controller.CamLeft2.canceled += ctx => {turnCam = 0;};
        cmap.PSX_Controller.CamRight2.canceled += ctx => {turnCam = 0;};

        //driving sword controller
        cmap.PSX_Controller.CamLeft2.performed += ctx => LeftSword();
        cmap.PSX_Controller.CamRight2.performed += ctx => RightSword();
        cmap.PSX_Controller.CamLeft2.canceled += ctx => SwordUp();
        cmap.PSX_Controller.CamRight2.canceled += ctx => SwordUp();

        //actions
        //cmap.PSX_Controller.Jump_Fly.started += ctx => JumpOrFly();
        cmap.PSX_Controller.Jump_Fly.started += ctx => {jumper = true;};
        cmap.PSX_Controller.Vehicle.started += ctx => VehicleInteract();

        cmap.PSX_Controller.Sword.started += ctx => {if(!driving)sword.Attack();};
        cmap.PSX_Controller.Interact.started += ctx => {if(!driving)sword.SheathSword();};

    }
    void OnEnable(){
        cmap.PSX_Controller.Enable();
    }
    void OnDisable(){
        cmap.PSX_Controller.Disable();
    }

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        wingAnimate = transform.Find("Wing").GetComponent<Wing>();
        sword = transform.Find("Sword").GetComponent<Sword>();
        inter = transform.Find("InteractSphere").GetComponent<Interactor>();
        rotY = transform.eulerAngles.y;
        ztScript = transform.Find("ZT").GetComponent<Ztarget>();

        curHealth = maxHealth;

        CamToPlayer();
    }

    //normal camera to player object
    public void CamToPlayer(){
        
        cam.GetComponent<CameraFollow>().target = transform;
        cam.GetComponent<CameraFollow>().rotOffset = camOffR;
        cam.GetComponent<CameraFollow>().posOffset = camOffP;
    }

    //shift to falling view
    public void CamToFallPlayer(){
        cam.GetComponent<CameraFollow>().rotOffset = Vector3.Slerp(cam.GetComponent<CameraFollow>().rotOffset, camOffR_fall, 5.0f);
        Debug.Log("AAAAGH!");
    }
    
    //camera attached to vehicle
    public void CamToVehicle(){
        
        cam.GetComponent<CameraFollow>().target = curVehicle;
        cam.GetComponent<CameraFollow>().rotOffset = camOffR_moto;
        cam.GetComponent<CameraFollow>().posOffset = camOffP_moto;
    }

    public void DebugUI(string d){
        debugTxt += (d+"\n");
    }

    // Update is called once per frame
    void FixedUpdate() {
        //clear debug ui text
        debugTxt = "";

        //reset movement
        if(!axisActive.Contains(1)){
            horDir = 0;
            verDir = 0;
        }

        //camera movement
        if(cam && !driving){
            //normal
            if(!ztargeting){
                rotY = transform.eulerAngles.y;
                transform.eulerAngles = new Vector3(0, rotY+(turnCam*camSpeed), 0);    
            }
            
        }

        float velZ = 0;
        float velX = 0;

        //normal movement
        if(!ztargeting){
            velZ = verDir * moveSpeed * Time.fixedDeltaTime;
            velX = horDir * moveSpeed * Time.fixedDeltaTime;
        }
        //z-targeting
        else{
            // velZ = verDir * moveSpeed * Time.fixedDeltaTime;
            // velX = horDir * moveSpeed * Time.fixedDeltaTime;

            //transform.RotateAround(curTarget.position,transform.up,horDir*moveSpeed*Time.fixedDeltaTime);
            //float r = Vector3.Distance(transform.position, curTarget.position);

            transform.LookAt(curTarget, transform.up);
            velZ = verDir * moveSpeed * Time.fixedDeltaTime;

            velX = horDir * moveSpeed * Time.fixedDeltaTime;


            

        }

        

        if(cc.isGrounded){
            //take fall damage if fell too hard
            if(fallDmg){
                curHealth -= Mathf.RoundToInt(Mathf.Abs(velY) / 10.0f);
            }

            velY = 0;
            curStamina = maxStamina;

            fallDmg = false;
        }

        //alt jump/fly
        if(jumper && curStamina > 0 && !driving){
            //rb.AddForce(Vector3.up*jumpForce*10, ForceMode.Impulse);
            velY += jumpForce;
            wingAnimate.FlapWing();
            curStamina -= staminaDepl;
            jumper = false;
        }

        //gravity
        velY += (Physics.gravity.y*gravityMod);
         //terminal velocity
        if(velY > terminalVel)
            velY = terminalVel;
        else if(velY < -(terminalVel*(4.0f/3.0f))){
            fallDmg = true;
        }
            

        //in motion
        // if(velY == 0.0 && velX == 0.0 && velZ == 0.0){
        //     moving = true;
        // }else{
        //     moving = false;
        // }


        //movement
        //rb.MovePosition(rb.position + ((transform.right*velX)+(transform.forward*velZ)));
        Vector3 movement = (transform.right*velX)+(transform.forward*velZ)+(transform.up*velY*Time.fixedDeltaTime); 
        if(!driving)
            cc.Move(movement);

        DebugUI("Velocity: " + movement.ToString());
        DebugUI("Camera Angle: " + transform.eulerAngles.ToString() + " - " + rotY.ToString());
        DebugUI("Grounded?: " + cc.isGrounded);
        DebugUI("Stamina: " + curStamina.ToString() + "/" + maxStamina.ToString());
        DebugUI("Health: " + curHealth.ToString() + "/" + maxHealth.ToString());
        DebugUI("Interactable: " + (inter.interactable ? inter.interactable.name : "null"));
        // if(curVehicle != null){
        //     DebugUI("Front RPM: " + curVehicle.GetComponent<AdvancedMotorcycle>().frontWheelCol.rpm.ToString("#.00"));
        //     DebugUI("Rear RPM: " + curVehicle.GetComponent<AdvancedMotorcycle>().rearWheelCol.rpm.ToString("#.00"));
        // }

        //debugger window
        if(debugTextUI){
            debugTextUI.text = debugTxt;
        }
    }



    //allows jumping and flying
    void JumpOrFly(){
        if(curStamina <= 0)
            return;

        velY += jumpForce;
        curStamina -= staminaDepl;
    }

    void ToggleZTarget(){
        if(ztScript == null){return;}       //can't z-target
        //ztScript.ShowTargets();

        //toggle z-target target
        Transform nt = ztScript.GetClosestTarget();
        if(nt != null && curTarget == null){                //first target
            Debug.Log("set target");
            curTarget = nt;
            ztargeting = true;
        }else if(curTarget != null){    
            Transform xt = ztScript.GetNextTarget(nt);
            if(xt == curTarget || axisActive[1] == 1){          //deactivate
                Debug.Log("deactivate");
                curTarget = null;
                ztargeting = false;
            }else if(xt != curTarget){                      //switch targets
                Debug.Log("switch targets");
                curTarget = xt;
                ztargeting = true;
            }
        }
    }


    //sword interaction on left side (ground/vehicle)
    void LeftSword(){
        if(driving && sword.hand == "none"){
            sword.hand = "left";
            sword.HoldLeft();
        }
    }

    //sword interaction on right side (ground/vehicle)
    void RightSword(){
        if(driving && sword.hand == "none"){
            sword.hand = "right";
            sword.HoldRight();
        }
    }

    //retract sword
    void SwordUp(){
        if(driving){
            sword.hand = "none";
            sword.DriveSheath();
        }
    }




    //allow interaction with a vehicle
    void VehicleInteract(){
        if(driving){
            curVehicle.GetComponent<Vehicle>().Dismount();
            curVehicle = null;
        }else{
            MountVehicle();
        }
    }

    //get on a vehicle
    void MountVehicle(){
        if(inter.interactable != null && inter.interactable.gameObject.tag == "motorcycle" && !driving && inter.interactable.GetComponent<Vehicle>().rider == null){
            driving = true;
            this.GetComponent<Collider>().enabled = false;
            cc.enabled = false;
            inter.interactable.GetComponent<Vehicle>().Mount(this.gameObject);
            curVehicle = inter.interactable;
            transform.eulerAngles = new Vector3(0,curVehicle.eulerAngles.y-90,0);
            sword.DriveSheath();
            CamToVehicle();
        }
    }


    /*
    void OnCollisionEnter(Collision c){
        Debug.Log("c");
        Vector3 hit = c.contacts[0].normal;
        Debug.Log(hit);
        float angle = Vector3.Angle(hit, Vector3.forward);
        if(Mathf.Approximately(angle,0)){
            Debug.Log("BONK!");
        }else{
            Debug.Log("oof");
        }
    }
    */

    void OnControllerColliderHit(ControllerColliderHit c){
        Vector3 hit = c.normal;
        //Debug.Log(hit);
        float angle = Vector3.Angle(hit, Vector3.up);
        //DebugUI("Hit Angle: " + Mathf.RoundToInt(angle).ToString());
        if(Mathf.Approximately(angle,180)){
            velY = 0;
        }
    }
    
    
}
