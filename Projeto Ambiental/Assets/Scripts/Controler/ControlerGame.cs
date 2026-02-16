using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ControlerGame : MonoBehaviour
{
    /*
    ========================================================================
    ControlerGame tem a função de controlar todos os atributos do jogo

    -> OnIncrementedCoinInGame(int value) Ligado a evento. Incrementa 
    moedas ao controlador

    -> OnIncrementedPointsInGame(int value) Ligado a evento. Incrementa 
    moedas ao controlador
    ========================================================================
    */
    private int points = 0;
    private int coins = 0;

    //Events ================================================================
    
    public delegate void UpdartedPointsText(int points);
    public event UpdartedPointsText UpdatedPoints;
    //=======================================================================

    //Scripts ===============================================================
    private ControlerBoxes controlerBoxes;
    private ControlerEnergy controlerEnergy;
    //=======================================================================

    void Awake() {
        controlerBoxes = GetComponent<ControlerBoxes>();
        controlerEnergy = GetComponent<ControlerEnergy>();
    }
    void Start() {
        controlerBoxes.CountBoxes();
        controlerEnergy.InitTimerLostEnergy();   
    }

    #region Events
    public void OnUpdatedCoinInGame(int value) {
        coins += value;
    }
    public void OnUpdatedPointInGame(int value) {
        points += value;
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
