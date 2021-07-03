using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDemo : MonoBehaviour
{
    public Rigidbody rb;

    public int mode = 1;

    public bool gas = false;
    public bool brake = false;
    private int[] turnVec = {0,0};

    //motorcycle stats
    private float curSpeed = 3.0f;
    public float maxSpeed = 10.0f;
    public float accelRate = 3.0f;      //m/s
    public float brakeRate = 5.0f;
    public float fricRate = 1.0f;
    public float turn = 1.0f;

    //controls
    Control_Map cmap;

    void Awake(){
        cmap = new Control_Map();
        //cmap.PSX_Controller.Jump_Fly.performed += ctx => {Debug.Log("MEH");};

        //bike movement (lean)
        cmap.PSX_Controller.MoveLeft.performed += ctx => {turnVec[0] = 1;};
        cmap.PSX_Controller.MoveRight.performed += ctx => {turnVec[1] = 1;};
        cmap.PSX_Controller.MoveLeft.canceled += ctx => {turnVec[0] = 0;};
        cmap.PSX_Controller.MoveRight.canceled += ctx =>{turnVec[1] = 0;};

        //gas/brake
        cmap.PSX_Controller.Jump_Fly.performed += ctx => {gas = true;};
        cmap.PSX_Controller.Jump_Fly.canceled += ctx => {gas = false;};

        cmap.PSX_Controller.Sword.performed += ctx => {brake = true;};
        cmap.PSX_Controller.Sword.canceled += ctx => {brake = false;};


        //camera movement
        cmap.PSX_Controller.CamLeft.performed += ctx => {};
        cmap.PSX_Controller.CamRight.performed += ctx => {};
        cmap.PSX_Controller.CamLeft.canceled += ctx => {};
        cmap.PSX_Controller.CamRight.canceled += ctx => {};

    }
    void OnEnable(){
        cmap.PSX_Controller.Enable();
    }
    void OnDisable(){
        cmap.PSX_Controller.Disable();
    }

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate(){
    
        if(mode == 1){


            //gas/brake
            if(gas){
                if(curSpeed < maxSpeed){
                    curSpeed += accelRate*Time.fixedDeltaTime;
                }
                rb.AddForce(transform.right*curSpeed);
                rb.drag = fricRate;
            }else if(brake){
                if(curSpeed > accelRate){
                    curSpeed -= accelRate*Time.fixedDeltaTime;
                }
                rb.AddForce(-transform.right*brakeRate);
                rb.drag = fricRate/4;
            }else if(!gas && !brake){
                rb.drag = fricRate/4;
            }

            //steering
            if(turnVec[0] == 1){
                transform.Rotate(Vector3.up*-turn);
            }else if(turnVec[1] == 1){
                transform.Rotate(Vector3.up*turn);
            }

            Debug.Log(rb.velocity.magnitude);

        }
    }
}
