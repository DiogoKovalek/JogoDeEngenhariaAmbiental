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
    private int coins = 0;
    private int collectibleInLevel = 0;
    private int multiplicadorDeBonus = 150;

    private float timeForStartGame = 2f;
    private float timeForTradeScene = 4f;


    [SerializeField] private GameObject listCollectibleForBonus;

    //Events ================================================================
    
    public delegate void UpdartedPointsText(int points);
    public event UpdartedPointsText UpdatedPoints;
    public delegate void StartedGameScreen(String level, float timeShowText);
    public event StartedGameScreen StartedGameS;
    public delegate void ShowedGameOverScreen();
    public event ShowedGameOverScreen ShowedGameOverS;
    public delegate void ShowedLevelCompleteScreen();
    public event ShowedLevelCompleteScreen ShowedLevelCompleteS;

    //Para o player
    public delegate void PlayerLostedTheGame();
    public event PlayerLostedTheGame PlayerLosted;
    public delegate void PlayerWonTheGame();
    public event PlayerWonTheGame PlayerWon;
    //=======================================================================

    //Scripts ===============================================================
    private ControlerBoxes controlerBoxes;
    private ControlerEnergy controlerEnergy;
    //=======================================================================

    void Awake() {
        controlerBoxes = GetComponent<ControlerBoxes>();
        controlerEnergy = GetComponent<ControlerEnergy>();

        //Classes staticas

    }
    IEnumerator Start() {
        ManagerInputs.DesactiveALLInput();
        controlerBoxes.CountBoxes();
        howMuchCollectibleInLevel();
        StartedGameS(ManagerAtributes.level.ToString(), timeForStartGame);
        yield return new WaitForSeconds(timeForStartGame);
        ManagerInputs.ActiveALLInput();

        controlerEnergy.StartTimerLostEnergy();
    }

    #region Status Level
    
    public void GameOver() {
        ShowedGameOverS();
        controlerEnergy.StopTimerLostEnergy();
        ManagerInputs.DesactiveALLInput();
        PlayerLosted();

        StartCoroutine(TradeScene("GameOver"));
    }
    public void LevelComplete() {
        ShowedLevelCompleteS();
        controlerEnergy.StopTimerLostEnergy();
        ManagerInputs.DesactiveALLInput();
        PlayerWon();

        //Savar Pontuacao para proxima fase
        ManagerAtributes.cachePoints = points;

        //Verificar se foi coletado todas a moedas
        if (checkedIfCollectAllCollectibles()) {
            ManagerAtributes.cacheBonusPoint = collectibleInLevel * multiplicadorDeBonus;
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
        else {
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
    public void OnUpdatedCoinInGame(int value) {
        coins += value;
    }
    public void OnUpdatedPointInGame(int value) {
        points += value;
        if(points < 0) points = 0;
        if(UpdatedPoints != null) UpdatedPoints(points);
    }
    #endregion

    #region Gets Components
    public ControlerBoxes GetControlerBoxes() {
        return controlerBoxes;
    }
    public ControlerEnergy GetControlerEnergy() {
        return controlerEnergy;
    }
    #endregion
}
