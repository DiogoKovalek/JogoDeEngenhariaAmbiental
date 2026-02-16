using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDepositeBox : MonoBehaviour, IInteractive {
    /*
    ====================================================================
    InteractiveDepositeBox tem como objetivo servir como um ponto de
    entrega de caixas
    ====================================================================
    */
    public void Interactive(Player player) {
        PlayerManageItem playerIM = player.GetPlayerManageItem();
        if (playerIM.GetTypeItem() == TypeItem.BOX) {
            playerIM.DepositItem();
        }
    }
}
