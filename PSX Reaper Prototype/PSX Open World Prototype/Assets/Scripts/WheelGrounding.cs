using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelGrounding : MonoBehaviour
{
	public bool isGrounded = false;
    public void OnTriggerStay(Collider c){
    	if(!isGrounded){
    		isGrounded = true;
    	}
    }
    public void OnTriggerExit(Collider c){
		isGrounded = false;
    }
}
