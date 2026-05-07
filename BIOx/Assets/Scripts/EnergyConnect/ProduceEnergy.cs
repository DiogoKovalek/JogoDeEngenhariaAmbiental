using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceEnergy : MonoBehaviour {
    [Header("Is Start Producing Energy")]
    [SerializeField] private bool isProducingEnergy = false;
    private List<ReceivesEnergy> listReceivesEnergy = new List<ReceivesEnergy>();
    public void EnergyON() {
        isProducingEnergy = true;
        changeStats();
    }
    public void EnergyOFF() {
        isProducingEnergy = false;
        changeStats();
    }
    public void EnergyInverse() {
        isProducingEnergy = !isProducingEnergy;
        changeStats();
    }
    public void StartConnection(ReceivesEnergy receives) {
        listReceivesEnergy.Add(receives);
    }
    private void changeStats() {
        foreach (var item in listReceivesEnergy) {
            item.ChangeStats(isProducingEnergy);
        }
    }
}
