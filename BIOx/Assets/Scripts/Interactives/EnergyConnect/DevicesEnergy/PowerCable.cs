using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed public class PowerCable : ReceivesEnergy
{
    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    } 
    protected override void deciveON() {
        base.deciveON();
        anim.SetBool("IsHaveEnergy", true);
    }
    protected override void deciveOFF() {
        base.deciveOFF();
        anim.SetBool("IsHaveEnergy", false);
    }
}
