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
    [SerializeField] LevelInfoManager levelInfoManager;
    [SerializeField] ControlerGame controlerGame;
    [SerializeField] ControlerBoxes controlerBoxes;
    [SerializeField] ControlerEnergy controlerEnergy;
    [SerializeField] ControlerSFX controlerSFX;
    [SerializeField] Player player;

    void Awake() {
        player.UpdatedEnergy += controlerEnergy.OnUpdatedEnergyInGame;
        player.UpdatedCoin += controlerGame.OnUpdatedCoinInGame;
        player.UpdatedPoint += controlerGame.OnUpdatedPointInGame;
        player.UpdatedBoxes += controlerBoxes.OnUpdateBoxesCollect;
        player.PlayedSFX += controlerSFX.OnPlaySFX;

        //Controler
        controlerGame.UpdatedPoints += pointsManager.OnUpdatePointsText;
        controlerGame.StartedGameS += levelInfoManager.OnStartGameScreen;
        controlerGame.ShowedGameOverS += levelInfoManager.OnShowGameOverScreen;
        controlerGame.ShowedLevelCompleteS += levelInfoManager.OnShowLevelCompleteScreen;
        controlerGame.PlayerLosted += player.OnPlayerLost;
        controlerGame.PlayerWon += player.OnPlayerWin;
        controlerEnergy.UpdatedBar += barEnergyManager.OnUpdateBarEnergy;
        controlerBoxes.UpdatedBox += countBoxesTextManager.OnUpdateBoxesInfo;
    }
}
