using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    /*
    ===========================================================
    MovementAnimation tem como objetivo realizar movimento de 
    animação para que os coletaveis tenhão mais vida
    ===========================================================
    */
    private float amplitude = 0.1f;
    private float frequencia = 2.5f;
    private Vector2 initicalPos;
    void Start() {
        initicalPos = transform.position;
    }
    void Update()
    {
        float posY = (float) (amplitude*Math.Sin(Time.time*frequencia));
        transform.position = new Vector2(initicalPos.x, initicalPos.y + posY);
    }
}
