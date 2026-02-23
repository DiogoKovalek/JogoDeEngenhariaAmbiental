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

    -> UpdCoin(int value) Incrementa ou decrementa a quantidade de moedas
    -> UpdPoint(int value) Incrementa ou decrementa a quantidade de pontoss
    =======================================================================
    */
    private Player player;
    void Start() {
        player = GetComponent<Player>();
    }
    public void UpdCoin(int value) {
        player.UpdCoinInControler(value);
    }
    public void UpdPoint(int value) {
        player.UpdPointInControler(value);
    }
    public void UpdEnergy(int value) {
        player.UpdEnergyInClontroler(value);
    }
}
