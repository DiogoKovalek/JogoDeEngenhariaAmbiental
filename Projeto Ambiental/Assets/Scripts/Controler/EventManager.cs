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
    [SerializeField] CountBoxesTextManager countBoxesTextManager;
    [SerializeField] PointsTextManager pointsManager;
    [SerializeField] ControlerGame controlerGame;
    [SerializeField] ControlerBoxes controlerBoxes;
    [SerializeField] ControlerEnergy controlerEnergy;
    [SerializeField] Player player;

    void Awake() {
        player.UpdatedEnergy += controlerEnergy.OnUpdatedEnergyInGame;
        player.UpdatedCoin += controlerGame.OnUpdatedCoinInGame;
        player.UpdatedPoint += controlerGame.OnUpdatedPointInGame;
        player.UpdatedBoxes += controlerBoxes.OnUpdateBoxesCollect;

        //Controler
        controlerGame.UpdatedPoints += pointsManager.OnUpdatePointsText;
        controlerEnergy.UpdatedBar += barEnergyManager.OnUpdateBarEnergy;
        controlerBoxes.UpdatedBox += countBoxesTextManager.OnUpdateBoxesInfo;
    }
}
