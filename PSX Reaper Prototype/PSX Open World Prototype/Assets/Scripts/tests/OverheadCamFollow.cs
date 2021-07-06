using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheadCamFollow : MonoBehaviour
{

	public Transform target;
	public Vector3 offset = Vector3.zero;


    // Start is called before the first frame update
    void Start(){
        offset = target.position - transform.position;
        offset = new Vector3(offset.x, transform.position.y, offset.z);
    }

    // Update is called once per frame
    void Update(){
        transform.position = new Vector3(target.position.x, 0, target.position.z) + offset;
    }

}
