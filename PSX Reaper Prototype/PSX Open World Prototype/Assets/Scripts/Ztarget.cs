using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ztarget : MonoBehaviour
{
	public List<Transform> targets = new List<Transform>();

    //lock onto closest target
    public Transform GetClosestTarget(){
        Transform b = null;
        float d = 1000;
        foreach(Transform t in targets){
            if(b == null || Vector3.Distance(t.position,transform.position) < d){
                b = t;
                d = Vector3.Distance(b.position,transform.position);
            }
        }
        return b;
    }

    public void ShowTargets(){
        string str = "";
        foreach(Transform t in targets){
            str += t.name + ' ';
        }
        Debug.Log(str);
    }

    public Transform GetNextTarget(Transform lastTarget){
        if(targets.Count == 0){return null;}

        int i = targets.IndexOf(lastTarget);
        int j = i+1;
        return targets[j%targets.Count];
    }


    private void OnTriggerEnter(Collider c){
        if(c.transform.tag == "Enemy"){
    	   targets.Add(c.transform);
        }
    }
    private void OnTriggerExit(Collider c){
        if(targets.Contains(c.transform) ){
    	   targets.Remove(c.transform);
        }
    }

    
}
