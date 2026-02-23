using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMoveInTarget : MonoBehaviour
{
    /*
    ==============================================================================
    EnemyMoveInTarget tem o objetivo de fazer a movimentacao dos inimigos, esse
    script funciona entregando um alvo, e o inimigo vai percorrer até o fim

    -> AtributeTarget(Vector2 diretion) atribui o alvo ao enemy
    ==============================================================================
    */

    private Vector2 target;
    private float speed;

    void Start() {
        speed = GetComponent<Enemy>().GetSpeed();
    }

    void Update() {
        if(Vector2.Distance(transform.position, target) <= 0.01f) {
            this.gameObject.SetActive(false);
        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    public void AtributeTarget(Vector2 target) {
        this.target = target;
    }
}
