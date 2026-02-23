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

    private int layerInteractive = 6;
    private int layerCollectible = 7;
    private int layerItem = 8;
    private int layerEnemy = 9;
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
        if(collision.gameObject.layer == layerCollectible) { // Collectable
            collision.GetComponent<ICollectible>().communicateWithPlayer(playerCC);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.layer == layerItem) { // Item
            if(playerMI.CheckIfIsLoadingItem() == false) { 
                collision.GetComponent<ItemBehaviour>().GetThisItem(playerMI);
            }
        }
        if(collision.gameObject.layer == layerEnemy) { // Enemy
            collideEnemy(collision);
        }
    }
    private void collideEnemy(Collider2D collision) {
        Enemy enemy = collision.GetComponent<Enemy>();
        Vector2 diretion = (transform.position - collision.gameObject.transform.position).normalized;
        player.TakeDamage(enemy.GetDamage(), enemy.GetSpeed(), diretion);

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
