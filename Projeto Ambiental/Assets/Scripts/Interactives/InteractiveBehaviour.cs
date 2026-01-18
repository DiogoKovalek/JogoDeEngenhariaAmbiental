using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBehaviour : MonoBehaviour {
    /*
    ====================================================================
    InteractiveBehaviour tem como objetivo armazenar valores de quanta
    engergia cada interação irá entregar ao Player

    -> Interactive(out int value, out bool isGet) ou entrega o valor 
    de energia que a interação disponibiliza, ou seta o valor para zero 
    para esvaziar o caminhão
    ====================================================================
    */
    [SerializeField] bool interactForGet;
    [SerializeField] int ValueForGet = 0;
    
    public void Interactive(out int value, out bool isGet) {
        if (interactForGet) {
            value = ValueForGet;
            isGet = true;
        }
        else {
            value = 0;
            isGet = false;
        }
    }
}