using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator animator;
    public bool sheathed = true;
    public bool comboPossible;
    public int comboStep = 0;
    public string hand = "none";

    private SwordBlade blade;

    // Start is called before the first frame update
    void Start(){
        animator = GetComponent<Animator>();
        blade = transform.Find("blade").GetComponent<SwordBlade>();
    }

    //attacks (ground)
    public void Attack(){
        if(sheathed){
            DrawSword();
            return;
        }else{
            if(comboStep == 0){
                animator.Play("swing_left");
                comboStep = 1;
                return;
            }else if(comboStep != 0 && comboPossible){
                comboPossible = false;
                comboStep += 1;
            }
        }

    }
    public void AllowCombo(){
        comboPossible = true;
    }
    public void Combo(){
        if(comboStep == 2)
            animator.Play("swing_right");
        if(comboStep == 3){
            animator.Play("chop");
            blade.curKnockback = blade.baseKnockback*2;
        }
    }
    public void ResetCombo(){
        comboPossible = false;
        comboStep = 0;
        blade.curKnockback = blade.baseKnockback;
    }

    //attacks
    public void ActivateBlade(){blade.canHit = true;}
    public void DeactivateBlade(){blade.canHit = false;}

    //draw and sheath
    public void DrawSword(){
        animator.SetTrigger("takeOut");
        sheathed = false;
        hand = "right";
        blade.canHit = true;
    }

    public void SheathSword(){
        animator.SetTrigger("putAway");
        sheathed = true;
        hand = "none";
        blade.canHit = false;
    }


    //vehicle interactions
    public void VehicleDismount(){
        animator.SetTrigger("putAway");
        sheathed = true;
    }
    public void DriveSheath(){
        animator.SetTrigger("putAway_vehicle");
        sheathed = true;
        hand = "none";
        blade.canHit = false;
        blade.clotheslined = false;
    }

    
    public void HoldLeft(){
        if(sheathed){
            animator.SetTrigger("driveLeft");
            sheathed = false;
        }
        blade.canHit = true;
        blade.clotheslined = true;
    }
    public void HoldRight(){
        if(sheathed){
            animator.SetTrigger("driveRight");
            sheathed = false;
        }
        blade.canHit = true;
        blade.clotheslined = false;
    }

}
