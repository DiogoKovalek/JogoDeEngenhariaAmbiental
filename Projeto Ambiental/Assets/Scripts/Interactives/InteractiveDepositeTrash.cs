using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDepositeTrash : MonoBehaviour, IInteractive {
    [SerializeField] private ProduceEnergy produceEnergy;
    public void Interactive(Player player) {
        PlayerManageItem playerIM = player.GetPlayerManageItem();
        if(playerIM.GetTypeItem() == TypeItem.TRASH) {
            playerIM.DepositItem();
            this.gameObject.SetActive(false);
            produceEnergy.EnergyON();
        }
    }
}
