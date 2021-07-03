using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBlade : MonoBehaviour
{
	[HideInInspector] public bool canHit = true;
	private Transform lastHit;
	public float baseKnockback = 100.0f;
	public float curKnockback = 100.0f;

	private Transform swordsman;

	void Start(){
		swordsman = transform.parent.parent;		//get the wielder of the blade
	}

    public void OnTriggerEnter(Collider c){
    	if(c.gameObject.tag == "Enemy" && canHit){
    		c.GetComponent<EnemyAI>().TakeDamage(1);
    		Knockback(c.transform);
    	}
    }

    private void Knockback(Transform o){
    	Rigidbody o_rb = o.GetComponent<Rigidbody>();
    	if(o_rb){
    		o_rb.AddForce(o_rb.mass*curKnockback*-o.forward);
    	}
    }
}
