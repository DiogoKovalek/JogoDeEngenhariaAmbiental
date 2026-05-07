using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed public class Sprinkler : ReceivesEnergy
{
    [SerializeField] private ParticleSystem Fertilizer;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    protected override void deciveON(){
        base.deciveON();
        anim.SetBool("IsEnergy", true);
        Fertilizer.Play();
    }
    protected override void deciveOFF(){
        base.deciveOFF();
        anim.SetBool("IsEnergy", false);
        Fertilizer.Stop();
    }
}
