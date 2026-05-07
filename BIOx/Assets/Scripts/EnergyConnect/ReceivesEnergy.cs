using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivesEnergy : MonoBehaviour
{
    [Header("Receives Energy")]
    [SerializeField] private ProduceEnergy generator;
    protected bool isHaveEnergy;

    void Awake() {
        generator.StartConnection(this);
    }

    public void ChangeStats(bool isHaveEnergy) {
        this.isHaveEnergy = isHaveEnergy;
        if(isHaveEnergy) deciveON();
        else deciveOFF();
    }
    protected virtual void deciveON(){}
    protected virtual void deciveOFF(){}
}
