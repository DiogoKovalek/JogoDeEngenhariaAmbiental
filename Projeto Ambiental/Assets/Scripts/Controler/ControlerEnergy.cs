using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerEnergy : MonoBehaviour
{
    /*
    =========================================================================
    ControlerEnergy tem a funcao de controlar a energia do jogo

    -> OnIncrementEnergyInGame(int value) Ligado a evento. Incremeta a
    energia que estava no player ao jogo
    =========================================================================
    */
    private int energy = 60;
    private int maxEnergy = 60;
    private int energyLostForSecond = 1;

    //Events ================================================================
    public delegate void UpdatedBarEnergy(float percentBar);
    public event UpdatedBarEnergy UpdatedBar;
    //=======================================================================

    public void InitTimerLostEnergy() {
        if(UpdatedBar != null) UpdatedBar(energy*100/maxEnergy);
        StartCoroutine(lostEnergyForSecond());
    }
    private IEnumerator lostEnergyForSecond() {
        yield return new WaitForSeconds(1.0f);
        OnUpdatedEnergyInGame(-energyLostForSecond);
        StartCoroutine(lostEnergyForSecond());
    }

    #region Events
    public void OnUpdatedEnergyInGame(int value) {
        energy += value;
        if(value > 0) energy = energy + value < maxEnergy ? energy + value : maxEnergy;
        else if(value < 0) energy = energy - energyLostForSecond > 0 ? energy - energyLostForSecond : 0;
        if(UpdatedBar != null) UpdatedBar(energy*100/maxEnergy);
        //checkIfNotEnergy();
    }
    #endregion
}
