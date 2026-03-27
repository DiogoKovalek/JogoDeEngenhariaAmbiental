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
    [SerializeField] PointsTextManager pointsManager;
    [SerializeField] StopwatchManager stopwatchManager;
    [SerializeField] LevelInfoManager levelInfoManager;
    [SerializeField] ControlerGame controlerGame;
    [SerializeField] ControlerTimerGame controlerTimerGame;
    [SerializeField] ControlerSFX controlerSFX;
    [SerializeField] Player player;

    void Awake() {
        player.UpdatedPoint += controlerGame.OnUpdatedPointInGame;
        player.PlayedSFX += controlerSFX.OnPlaySFX;

        //Controler
        controlerGame.UpdatedPoints += pointsManager.OnUpdatePointsText;
        controlerGame.StartedGameS += levelInfoManager.OnStartGameScreen;
        controlerGame.ShowedGameOverS += levelInfoManager.OnShowGameOverScreen;
        controlerGame.ShowedLevelCompleteS += levelInfoManager.OnShowLevelCompleteScreen;
        controlerGame.PlayerLosted += player.OnPlayerLost;
        controlerGame.PlayerWon += player.OnPlayerWin;
        controlerTimerGame.UpdatedStopwatch += stopwatchManager.OnUpdateStopwatch;
    }
}
