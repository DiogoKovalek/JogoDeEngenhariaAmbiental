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
    -> GetBox(GameObject Box) Player pega a caixa e carrega
    -> DropBox() Player joga a caixa para alguma direcao quando toma dano

    //In Controler
    -> UpdEnergyInControler(int valuer) adiciona ou decrementa Energia ao Controler
    -> UpdCoinInControler(int valuer) adiciona ou decrementa Coin ao Controler
    -> UpdPointInControler(int valuer) adiciona ou decrementa Point ao Controler

    //Get Component
    -> Geters de todos os components
    ==================================================================
    */
    public int valueEnergyInTruck = 0;
    public int maxValueEnergyInTruck = 50;

    //Events =========================================================
    public delegate void UpdatedEnergyInGame(int value);
    public event UpdatedEnergyInGame UpdatedEnergy;
    public delegate void UpdatedCoinInGame(int value);
    public event UpdatedCoinInGame UpdatedCoin;
    public delegate void UpdatedPointInGame(int value);
    public event UpdatedPointInGame UpdatedPoint;
    public delegate void UpdatedBoxesCollect(byte value);
    public event UpdatedBoxesCollect UpdatedBoxes;
    //================================================================

    //Scripts ========================================================
    private ManagerCollideTriggers managerCollideTriggers;
    private MovePlayer movePlayer;
    private PlayerCommunicateCollectible playerCommunicateCollectible;
    private PlayerManageItem playerManageItem;
    //================================================================

    void Awake() {
        managerCollideTriggers = GetComponent<ManagerCollideTriggers>();
        movePlayer = GetComponent<MovePlayer>();
        playerCommunicateCollectible = GetComponent<PlayerCommunicateCollectible>();
        playerManageItem = GetComponent<PlayerManageItem>();
    }
    public void AddEnergyInTruck(int value) {
        if (valueEnergyInTruck != maxValueEnergyInTruck) {
            valueEnergyInTruck += value;
            if(valueEnergyInTruck > maxValueEnergyInTruck) valueEnergyInTruck = maxValueEnergyInTruck;
        }
    }
    public void EmptyEnergy() {
        UpdEnergyInClontroler(valueEnergyInTruck);
        valueEnergyInTruck = 0;
    }
    
    #region For Controler
    public void UpdEnergyInClontroler(int value) {
        if(UpdatedEnergy != null) UpdatedEnergy(value);
    }
    public void UpdCoinInControler(int value) {
        if(UpdatedCoin != null) UpdatedCoin(value);
    }
    public void UpdPointInControler(int value) {
        if(UpdatedPoint != null) UpdatedPoint(value);
    }
    public void UpdBoxesInControler(byte value) {
        if(UpdatedBoxes != null) UpdatedBoxes(value);
    }
    #endregion

    #region GetComponests
    public ManagerCollideTriggers GetManagerCollideTriggers() {
        return managerCollideTriggers;
    }
    public MovePlayer GetMovePlayer() {
        return movePlayer;
    }
    public PlayerCommunicateCollectible GetPlayerCommunicateCollectible() {
        return playerCommunicateCollectible;
    }
    public PlayerManageItem GetPlayerManageItem() {
        return playerManageItem;
    }
    #endregion
}
