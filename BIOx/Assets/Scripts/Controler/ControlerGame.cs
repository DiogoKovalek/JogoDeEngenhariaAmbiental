using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ControlerGame : MonoBehaviour
{
    /*
    ========================================================================
    ControlerGame tem a função de controlar todos os atributos do jogo

    -> GameOver() da game over na fase

    -> LevelComplete() completa a fase

    -> OnIncrementedCoinInGame(int value) Ligado a evento. Incrementa 
    moedas ao controlador

    -> OnIncrementedPointsInGame(int value) Ligado a evento. Incrementa 
    moedas ao controlador
    ========================================================================
    */
    private int points = 0;
    private int collectibleInLevel = 0;

    private float timeForStartGame = 2f;
    private float timeForTradeScene = 4f;

    private bool endLevel = false; // evitar perder vida quando ja esta morto


    [SerializeField] private GameObject listCollectibleForBonus;

    //Events ================================================================
    
    public delegate void UpdartedPointsText(int points);
    public event UpdartedPointsText UpdatedPoints;
    public delegate void UpdatedTextLife();
    public event UpdatedTextLife UpdatedLife;
    public delegate void StartedGameScreen(String level, float timeShowText);
    public event StartedGameScreen StartedGameS;
    public delegate void ShowedGameOverScreen();
    public event ShowedGameOverScreen ShowedGameOverS;
    public delegate void ShowedTimeOverScreen();
    public event ShowedTimeOverScreen ShowedTimeOverS;
    public delegate void ShowedLevelCompleteScreen();
    public event ShowedLevelCompleteScreen ShowedLevelCompleteS;
    public delegate void ResetedActionLerp();
    public event ResetedActionLerp ResetedActionInInfoScreen;

    //Para o player
    public delegate void PlayerLostedTheGame();
    public event PlayerLostedTheGame PlayerLosted;
    public delegate void PlayerWonTheGame();
    public event PlayerWonTheGame PlayerWon;
    public delegate void PlayerLostTime();
    public event PlayerLostTime PlayerTimed;
    //=======================================================================

    //Scripts ===============================================================
    private ControlerTimerGame controlerTime;
    //=======================================================================

    void Awake() {
        controlerTime = GetComponent<ControlerTimerGame>();

    }
    IEnumerator Start() {
        UpdatedLife();
        ManagerInputs.DesactiveALLInput();
        howMuchCollectibleInLevel();
        StartedGameS(ManagerAtributes.level.ToString(), timeForStartGame);
        controlerTime.initializeTime();
        yield return new WaitForSeconds(timeForStartGame);
        ManagerInputs.ActiveALLInput();
        controlerTime.StartTimer();

    }

    #region Status Level
    
    public void GameOver() {
        endLevel = true;
        ShowedGameOverS();
        ManagerInputs.DesactiveALLInput();
        PlayerLosted();

        StartCoroutine(TradeScene("GameOver"));
    }
    public void TimeOver() {
        ShowedTimeOverS();
        ManagerInputs.DesactiveALLInput();
        PlayerTimed();
        if(!endLevel) ManagerAtributes.life--;
        UpdatedLife();

        StartCoroutine(TradeScene("TimeIsUp"));
    }
    public void LevelComplete() {
        endLevel = true;
        ShowedLevelCompleteS();
        controlerTime.StopTime();
        ManagerInputs.DesactiveALLInput();
        PlayerWon();

        //Savar Pontuacao para proxima fase
        ManagerAtributes.cachePoints = points;

        //Verificar se foi coletado todas a moedas
        if (checkedIfCollectAllCollectibles()) {
            //ManagerAtributes.cacheBonusPoint = collectibleInLevel * ManagerAtributes.multiplierBonus;
            ManagerAtributes.cacheBonusPoint = ManagerAtributes.cachePoints * ManagerAtributes.multiplierBonus;
        }
        StartCoroutine(TradeScene("Load"));
    }

    private IEnumerator TradeScene(String scene) {
        yield return new WaitForSeconds(timeForTradeScene);
        if(scene == "GameOver") {
            ManagerScenes.SceneToGameOver();
        }else if (scene == "Load") {
            ManagerScenes.SceneToLoadScreen();
        }
        else if (scene == "TimeIsUp") {
            if(ManagerAtributes.life <= 0) {
                ResetedActionInInfoScreen();
                GameOver();
            }    
            else ManagerScenes.RestartLevel();
        }else {
            Debug.LogError("Scene \"" + scene + "\" not found");
        }
    }

    private void howMuchCollectibleInLevel() {
        collectibleInLevel = listCollectibleForBonus.transform.childCount;
    }
    private bool checkedIfCollectAllCollectibles() {
        return listCollectibleForBonus.transform.childCount == 0;
    }
    #endregion

    #region Events
    public void OnUpdatedPointInGame(int value) {
        points += value;
        if(points < 0) points = 0;
        if(UpdatedPoints != null) UpdatedPoints(points);
    }
    public void OnUpdatedLifeInGame(int value) {
        ManagerAtributes.life += value;
        UpdatedLife();
    }
    public void OnToachedInGoalSign(){
        LevelComplete();
    }
    public void OnPlayerLostLife() {
        ManagerAtributes.life--;
        UpdatedLife();
        controlerTime.StopTime();
        if(ManagerAtributes.life <= 0) GameOver();
    }
    public void OnRespawnPlayer() {
        controlerTime.PlayTime();
    }
    #endregion

    #region Gets Components
    public ControlerTimerGame GetControlerTimerGame(){
        return controlerTime;
    }
    #endregion
}
