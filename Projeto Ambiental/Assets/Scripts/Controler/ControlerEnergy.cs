using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerEnergy : MonoBehaviour
{
    /*
    =========================================================================
    ControlerEnergy tem a funcao de controlar a energia do jogo

    -> StartTimerLostEnergy() comeca o cronometro de perder energia
    -> StopTimerLostEnergy() para o cronometro de perder energia

    -> OnIncrementEnergyInGame(int value) Ligado a evento. Incremeta a
    energia que estava no player ao jogo
    =========================================================================
    */
    private int energy = 60;
    private int maxEnergy = 60;
    private int energyLostForSecond = 1;
    private Coroutine timerLostEnergy;

    private ControlerGame controlerGame;

    //Events ================================================================
    public delegate void UpdatedBarEnergy(float percentBar);
    public event UpdatedBarEnergy UpdatedBar;
    //=======================================================================
    void Start() {
        controlerGame = GetComponent<ControlerGame>();
        OnUpdatedEnergyInGame(0); // Setar a UI
    }
    public void StartTimerLostEnergy() {
        if(UpdatedBar != null) UpdatedBar(energy*100/maxEnergy);
        timerLostEnergy = StartCoroutine(lostEnergyForSecond());
    }
    public void StopTimerLostEnergy() {
        StopCoroutine(timerLostEnergy);
    }
    private IEnumerator lostEnergyForSecond() {
        yield return new WaitForSeconds(1.0f);
        OnUpdatedEnergyInGame(-energyLostForSecond);
        timerLostEnergy = StartCoroutine(lostEnergyForSecond());
    }

    private void checkIfNotEnergy() {
        if(energy <= 0) controlerGame.GameOver();
    }

    #region Events
    public void OnUpdatedEnergyInGame(int value) {
        energy += value;
        if(value > 0) energy = energy + value < maxEnergy ? energy + value : maxEnergy;
        else if(value < 0) energy = energy - energyLostForSecond > 0 ? energy - energyLostForSecond : 0;
        if(UpdatedBar != null) UpdatedBar(energy*100/maxEnergy);
        checkIfNotEnergy();
    }
    #endregion
}
