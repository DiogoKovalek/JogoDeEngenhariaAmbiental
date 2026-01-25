using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ControlerGame : MonoBehaviour
{
    /*
    ========================================================================
    ControlerGame tem a função de controlar todos os atributos do jogo

    -> OnIncrementEnergyInGame(int value) Ligado a evento. Incremeta a
    energia que estava no player ao jogo

    -> OnIncrementedCoinInGame(int value) Ligado a evento. Incrementa 
    moedas ao controlador

    -> OnIncrementedPointsInGame(int value) Ligado a evento. Incrementa 
    moedas ao controlador
    ========================================================================
    */
    private int timeInSeconds = 0;
    private int points = 0;
    private int coins = 0;
    private int energy = 100;
    private int maxEnergy = 300;

    //Events ================================================================
    public delegate void UpdatedBarEnergy(float percentBar);
    public event UpdatedBarEnergy UpdatedBar;
    public delegate void UpdartedPointsText(int points);
    public event UpdartedPointsText UpdatedPoints;
    //=======================================================================

    void Start() {
        StartCoroutine(teste());
    }
    private IEnumerator teste() {
        yield return new WaitForSeconds(1f);
        Debug.Log("===\n" +
                "Coins : " + coins + " ===" + 
                "Points: " + points + " === ");
        StartCoroutine(teste());
    }

    public void OnIncrementEnergyInGame(int value) {
        energy += value;
        if(UpdatedBar != null) UpdatedBar(energy*100/maxEnergy);
        Debug.Log(energy*100/maxEnergy);
        // -- se energy >= maxEnergy finaliza a fase
    }

    public void OnIncrementedCoinInGame(int value) {
        coins += value;
    }
    public void OnIncrementedPointInGame(int value) {
        points += value;
        UpdatedPoints(points);
    }
}
