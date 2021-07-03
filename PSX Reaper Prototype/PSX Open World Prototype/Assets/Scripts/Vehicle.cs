using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    //properties
    [HideInInspector] public GameObject rider;
    protected Transform seat;
    public bool driving = false;
    protected Rigidbody rb;

     //attach a passenger
    public void Mount(GameObject c){
        if(rider == null){
            rider = c;
            driving = true;
            c.transform.position = seat.transform.position;
            c.transform.parent = seat;
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,transform.eulerAngles.z);

            Debug.Log("ride on shooting star!");
            rb.velocity = Vector3.zero;
        }
    }

    //remove the passenger
    public void Dismount(){
        if(driving && rider != null){
            rider.transform.parent = null;
            rider.transform.position = transform.Find("Dismount").transform.position;
            rider.transform.GetComponent<Collider>().enabled = true;
            rider.transform.GetComponent<CharacterController>().enabled = true;
            driving = false;
            
            Debug.Log("bike machine broke");

            FullDismount();
        }
    }

    //unparent the passenger
    public void FullDismount(){
        if(!driving && rider != null){
            rider.GetComponent<PSX_Movement>().driving = false;
            rider.GetComponent<PSX_Movement>().CamToPlayer();
            rider = null;

            Debug.Log("deadass");
        }
        
    }
}
