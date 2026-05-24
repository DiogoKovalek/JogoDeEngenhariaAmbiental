using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*
    ==================================================================
    Enemy tem a funcao de guardar os valores dos inimigos

    //Geters
    -> Geters dos atributos
    ==================================================================
    */

    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private Animator anim;
    void Awake() {
        anim = GetComponent<Animator>();
    }
    public float GetSpeed() {
        return speed;
    }
    public void SetSpeed(float speed) {
        this.speed = speed;
    }
    public int GetDamage() {
        return damage;
    }
    public Animator GetAnimator() {
        return anim;
    }
}
