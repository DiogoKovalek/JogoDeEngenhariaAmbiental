using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    /*
    ==================================================================
    Player serve como um manager de todos as outras classes, então se
    uma classe prescisar se comunicar com outra, ela deve conversar 
    com Player.

    -> AddEnergyInTruck(int value) adiciona engergia no caminão para 
    depois esvaziar
    -> EmptyEnergy() metodo para tranformar todo valueEnergyInTruck
    para energia no pronta

    //In Controler
    -> AddEnergyInControler(int valuer) adiciona Energia ao Controler
    -> AddCoinInControler(int valuer) adiciona Coin ao Controler
    -> AddPointInControler(int valuer) adiciona Point ao Controler
    ==================================================================
    */
    public int valueEnergyInTruck = 0;
    public int maxValueEnergyInTruck = 50;


    //Events =========================================================
    public delegate void IncrementedEnergyInGame(int value);
    public event IncrementedEnergyInGame IncrementedEnergy;
    public delegate void IncrementedCoinInGame(int value);
    public event IncrementedCoinInGame IncrementedCoin;
    public delegate void IncrementedPointInGame(int value);
    public event IncrementedPointInGame IncrementedPoint;

    //================================================================

    public void AddEnergyInTruck(int value) {
        if (valueEnergyInTruck != maxValueEnergyInTruck) {
            valueEnergyInTruck += value;
            if(valueEnergyInTruck > maxValueEnergyInTruck) valueEnergyInTruck = maxValueEnergyInTruck;
        }
    }
    public void EmptyEnergy() {
        AddEnergyInClontroler(valueEnergyInTruck);
        valueEnergyInTruck = 0;
    }
    #region In Controler
    public void AddEnergyInClontroler(int value) {
        if(IncrementedEnergy != null) IncrementedEnergy(value);
    }
    public void AddCoinInControler(int value) {
        if(IncrementedCoin != null) IncrementedCoin(value);
    }
    public void AddPointInControler(int value) {
        if(IncrementedPoint != null) IncrementedPoint(value);
    }
    #endregion
}
