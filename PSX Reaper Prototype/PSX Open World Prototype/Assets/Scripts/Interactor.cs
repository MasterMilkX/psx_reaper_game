using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Transform interactable;

    void OnTriggerEnter(Collider c){
        if(c.gameObject == transform.parent.gameObject)
            return;
        if(c.gameObject.tag == "motorcycle"){
            interactable = c.transform;
        }
    }

    void OnTriggerExit(Collider c){
        if(c.gameObject.transform == interactable){
            interactable = null;
        }
    }
}
