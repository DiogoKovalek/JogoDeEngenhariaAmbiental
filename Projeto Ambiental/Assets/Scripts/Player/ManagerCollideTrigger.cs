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

    private int layerInteractive = 6;
    private int laerCollectible = 7;
    void Awake() {
        player = GetComponent<Player>();
        playerCC = GetComponent<PlayerCommunicateCollectible>();
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == layerInteractive) {
            int value = 0;
            bool isGet = false;
            collision?.GetComponent<InteractiveBehaviour>().Interactive(out value, out isGet);
            if (isGet) {
                player.AddEnergyInTruck(value);
            }
            else {
                player.EmptyEnergy();
            }
        }
        if(collision.gameObject.layer == laerCollectible) {
            collision.GetComponent<ICollectible>().communicateWithPlayer(playerCC);
            Destroy(collision.gameObject);
        }
    }
}
