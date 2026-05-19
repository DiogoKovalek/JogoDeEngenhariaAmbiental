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
    [SerializeField] private Player player;
    [SerializeField] private GameObject UI;

    private PointsTextManager pointsManager;
    private StopwatchManager stopwatchManager;
    private LevelInfoManager levelInfoManager;
    private ControlerGame controlerGame;
    private ControlerTimerGame controlerTimerGame;
    private ControlerSFX controlerSFX;

    void Awake() {
        //Player
        if(player == null){
            player = FindObjectOfType<Player>()?.GetComponent<Player>();
        }

        // Controler
        controlerGame = GetComponent<ControlerGame>();
        controlerTimerGame = GetComponent<ControlerTimerGame>();
        controlerSFX = GetComponentInChildren<ControlerSFX>();

        if(UI == null){
            UI = GameObject.Find("Canvas");
        }
        pointsManager = UI.GetComponent<PointsTextManager>();
        stopwatchManager = UI.GetComponent<StopwatchManager>();
        levelInfoManager = UI.GetComponent<LevelInfoManager>();
        
        startEvents();
    }

    private void startEvents(){
        player.UpdatedPoint += controlerGame.OnUpdatedPointInGame;
        player.ToachedGoalSign += controlerGame.OnToachedInGoalSign;
        player.playerLostedAllLife += controlerGame.OnPlayerLostAllLifes;
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
