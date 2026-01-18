using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    /*
    ===========================================================================================
    EventManager Tem a função de controlar todos os evento do jogo
    ===========================================================================================
    */
    [SerializeField] BarEnergyManager barEnergyManager;
    [SerializeField] ControlerGame controlerGame;
    [SerializeField]Player player;

    void Start() {
        player.IncrementedEnergy += controlerGame.OnIncrementEnergyInGame;
        player.IncrementedCoin += controlerGame.OnIncrementedCoinInGame;
        player.IncrementedPoint += controlerGame.OnIncrementedPointInGame;

        controlerGame.UpdatedBar += barEnergyManager.OnUpdateBarEnergy;
    }
}
