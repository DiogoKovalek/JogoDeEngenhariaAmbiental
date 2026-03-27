using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible {
    /*
    ========================================================================
    Coin tem a funcionalidade de incrementar moedas ao jogador e pontos ao
    jogador
    ========================================================================
    */
    [SerializeField] private int valuePoint = 100;
    public void communicateWithPlayer(PlayerCommunicateCollectible playerCC) {
        playerCC.UpdPoint(valuePoint);
    }
}
