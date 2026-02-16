using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveEnergy : MonoBehaviour, IInteractive {
    /*
    ====================================================================
    InteractiveEnergy tem como objetivo armazenar valores de 
    quanta engergia cada interação irá entregar ao Player
    ====================================================================
    */
    [SerializeField] bool interactForGet;
    [SerializeField] int ValueForGet = 0;
    
    public void Interactive(Player player) {
        if (interactForGet) {
            player.AddEnergyInTruck(ValueForGet);
        }
        else {
            player.EmptyEnergy();
        }
    }
}