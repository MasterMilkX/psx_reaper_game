using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start(){
        animator = GetComponent<Animator>();
    }

    public void FlapWing(){
        animator.SetTrigger("Fly");
    }
}
