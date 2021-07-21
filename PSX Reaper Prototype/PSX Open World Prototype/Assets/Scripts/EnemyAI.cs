using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	private Rigidbody rb;
	public int health = 1000;

	private float graceAmt = 0.2f;
	private bool hit = false;
	private MeshRenderer mr;
	private Color ogColor;

    private MasterScript mscript;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        ogColor = mr.material.color;
        mscript = GameObject.Find("MasterScript").GetComponent<MasterScript>();
    }

    // Update is called once per frame
    void Update(){
        
    }


    // health // 

    //grace period before next hit
    public IEnumerator GracePeriod(){
    	hit = true;
    	mr.material.color = Color.red;
    	yield return new WaitForSeconds(graceAmt);
    	hit = false;
    	mr.material.color = ogColor;
    }

    //take some damage from a sword
    public void TakeDamage(int dmg){
    	if(!hit){
    		hit = true;
    		health -= dmg;
    		StartCoroutine(GracePeriod());
    		Die();
    	}
    }

    //then perish <.<
    public void Die(){
    	if(health <= 0){
            //remove as target if ztargeted


    		Destroy(this.gameObject);
    	}
    }
}
