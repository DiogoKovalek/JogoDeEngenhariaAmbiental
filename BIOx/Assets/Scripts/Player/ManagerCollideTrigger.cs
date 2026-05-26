using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCollideTriggers : MonoBehaviour
{
    /*
    ==========================================================================
    Classe que controla todos as colisões de Trigger do player

    -> DetectedEnemyBeforeInvunerable() Corrige o problema de quando o player
    deixa de ser invensivel, o inimigo poderia nao dar dano se o colisor ja
    estivese ativo, dessa forma usa um circle overlap para detectar a colisao
    ==========================================================================
    */
    private Player player;
    private PlayerCommunicateCollectible playerCC;
    private PlayerManageItem playerMI;

    private CircleCollider2D circleCollision;

    //Layers
    private const int layerWater = 4;
    private const int layerInteractive = 6;
    private const int layerCollectible = 7;
    private const int layerItem = 8;
    private const int layerEnemy = 9;
    private const int layerPlayer = 10;

    //Tag
    private const String tagGoalSign = "GoalSign";
    private const String tagSpike = "Spike";
    //private const String tagBridge = "Bridge";
    void Awake() {
        player = GetComponent<Player>();  
        circleCollision = GetComponent<CircleCollider2D>();
    }
    void Start() {
        playerCC = player.GetPlayerCommunicateCollectible();
        playerMI = player.GetPlayerManageItem();
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == layerInteractive) { // Interactive
            collision?.GetComponent<IInteractive>().Interactive(player);
        }
        else if(collision.gameObject.layer == layerCollectible) { // Collectable
            collision.GetComponent<ICollectible>().communicateWithPlayer(playerCC);
            if(collision.transform.CompareTag("Coin")) player.PlaySFX(SFXSound.COIN);
            if(collision.transform.CompareTag("Heart")) player.PlaySFX(SFXSound.LIFE);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.layer == layerItem) { // Item
            if(playerMI.CheckIfIsLoadingItem() == false) { 
                collision.GetComponent<ItemBehaviour>().GetThisItem(playerMI);
            }
        }
        else if(collision.gameObject.layer == layerEnemy) { // Enemy
            collideEnemy(collision);
            player.PlaySFX(SFXSound.DAMAGE);
        }
        else if(collision.CompareTag(tagGoalSign)){ //Goal Sign
            player.ToachGoalSign();
        }
        /*
        }else if (collision.CompareTag(tagBridge)){
            Debug.Log("Ponte");
            Physics2D.IgnoreLayerCollision(layerPlayer, layerWater, true);
        }
        */
    }
    
    /*
    void OnTriggerExit2D(Collider2D collision){
        if (collision.CompareTag(tagBridge)){
            Debug.Log("Saiu da ponte");
            Physics2D.IgnoreLayerCollision(layerPlayer, layerWater, false);
        }
    }
    */
    
    private void collideEnemy(Collider2D collision) {
        if (collision.CompareTag(tagSpike)) {
            player.TakeDamage(0,0,Vector2.zero);
        }else{
            Enemy enemy = collision.GetComponent<Enemy>();
            Vector2 diretion = (transform.position - collision.gameObject.transform.position).normalized;
            player.TakeDamage(enemy.GetDamage(), enemy.GetSpeed(), diretion);
        }

        /* Para se caso exista inimigos que facam algo espeifio
        IEnemy ene = collision?.GetComponente<IEnemy>();
        if(ene != null){
            ...
        }
        */
    }

    public void DetectedEnemyBeforeInvunerable() {
        Vector2 posCircle = (Vector2) transform.position + circleCollision.offset;
        Collider2D collider = Physics2D.OverlapCircle(posCircle, circleCollision.radius, 1 << layerEnemy);
        if(collider != null) collideEnemy(collider);
    }
}
