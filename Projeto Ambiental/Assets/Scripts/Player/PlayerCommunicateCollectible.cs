using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommunicateCollectible : MonoBehaviour
{
    /*
    =======================================================================
    PlayerCommunicateCollectible tem o objetivo de realizar a comunicação
    dos objetos até o player, independente se forem moedas, power-ups ou
    qualquer tipo de coletavel.
    haverão metodos aqui para cada tipo de coletavel e como ele irá se
    comportar

    -> AddCoin(int value) Incrementa a quantidade de moedas
    -> AddPoint(int value) Incrementa a quantidade de pontos
    =======================================================================
    */
    private Player player;
    void Start() {
        player = GetComponent<Player>();
    }
    public void AddCoin(int value) {
        player.AddCoinInControler(value);
    }
    public void AddPoint(int value) {
        player.AddPointInControler(value);
    }
}
