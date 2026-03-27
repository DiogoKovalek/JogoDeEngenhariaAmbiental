using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour, ICollectible
{
    /*
    =======================================================
    Energy tem a funcao de incrementar energia do player e
    adicionar ou remover pontos
    =======================================================
    */
    [SerializeField] private int valuePoints;
    public void communicateWithPlayer(PlayerCommunicateCollectible playerCC) {
            playerCC.UpdPoint(valuePoints);
    }
}
