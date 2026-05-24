using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : ReceivesEnergy
{
    private Animator anim;
    private float[] indexList = {0f, 0.5f, 1f};
    [SerializeField] private VEGETABLE vegetal;

    void Start() {
        anim = GetComponent<Animator>();
        switch (vegetal) {
            case VEGETABLE.Alface:
                anim.SetFloat("Index", indexList[0]);
                break;
            case VEGETABLE.Brocolis:
                anim.SetFloat("Index", indexList[1]);
                break;
            case VEGETABLE.Cenoura:
                anim.SetFloat("Index", indexList[2]);
                break;
            default:
                anim.SetFloat("Index", indexList[0]);
                break;
        }
    }
/*
    IEnumerator Start() {
        yield return new WaitForSeconds(2.0f);
        deciveON();
    }
    */
    protected override void deciveON() {
        base.deciveON();
        anim.SetBool("On", true);
    }
    protected override void deciveOFF() {
        base.deciveOFF();
    }
}

enum VEGETABLE {
    Alface,
    Brocolis,
    Cenoura
}
