using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCollideTriggers : MonoBehaviour
{
    /*
    ==========================================================================
    Classe que controla todos as colisões de Trigger do player
    ==========================================================================
    */
    private Player player;
    private PlayerCommunicateCollectible playerCC;
    private PlayerManageItem playerMI;

    private int layerInteractive = 6;
    private int layerCollectible = 7;
    private int layerItem = 8;
    void Awake() {
        player = GetComponent<Player>();  
    }
    void Start() {
        playerCC = player.GetPlayerCommunicateCollectible();
        playerMI = player.GetPlayerManageItem();
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == layerInteractive) { // Interactive
            collision?.GetComponent<IInteractive>().Interactive(player);
        }
        if(collision.gameObject.layer == layerCollectible) { // Collectable
            collision.GetComponent<ICollectible>().communicateWithPlayer(playerCC);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.layer == layerItem) {
            if(playerMI.CheckIfIsLoadingItem() == false) { // Item
                collision.GetComponent<ItemBehaviour>().GetThisItem(playerMI);
            }
        }
    }
}
