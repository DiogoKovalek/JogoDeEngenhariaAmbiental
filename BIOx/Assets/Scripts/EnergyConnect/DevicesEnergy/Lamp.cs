using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed public class Lamp : ReceivesEnergy
{
    private Animator anim;
    [SerializeField] private GameObject GBlight;
    void Start() {
        anim = GetComponent<Animator>();
    }
    protected override void deciveON() {
        base.deciveON();
        anim.SetBool("IsHaveEnergy", true);
        GBlight.SetActive(true);
    }
    protected override void deciveOFF() {
        base.deciveOFF();
        anim.SetBool("IsHaveEnergy", false);
        GBlight.SetActive(false);
    }
}
