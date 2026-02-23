using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemyDirection : MonoBehaviour {
    /*
    ==================================================================
    SpawnerEnemyDirection tem a funcao de servir como um spawner de 
    inimigos do tipo de movimentacao EnemyMoveInDiretion
    ==================================================================
    */

    [SerializeField] private EnemyMoveInTarget enemyPrefab;
    [SerializeField] private Transform initialPoint;
    [SerializeField] private Transform finalPoint;
    [SerializeField] private GameObject objListForEnemys;
    [SerializeField] private float speedSpawner;

    private Vector2 direction;
    void Start() {
        direction = (finalPoint.position - initialPoint.position).normalized;
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy() {
        GameObject enemy = GetEnemyInList();
        if(enemy != null) { // Existe um para ativar
            enemy.transform.position = initialPoint.transform.position;
            enemy.SetActive(true);
        }
        else { // Deve-se criar um novo
            enemy = Instantiate(enemyPrefab.gameObject, initialPoint.position, enemyPrefab.transform.rotation, objListForEnemys.transform);
            enemy.GetComponent<EnemyMoveInTarget>().AtributeTarget(finalPoint.position);
        }
        yield return new WaitForSeconds(speedSpawner);
        StartCoroutine(SpawnEnemy());
    }

    private GameObject GetEnemyInList() {
        GameObject ene = null;
        for(int i = 0; i < objListForEnemys.transform.childCount; i++){
            ene = objListForEnemys.transform.GetChild(i).gameObject;
            if(!ene.activeInHierarchy) return ene;
        }
        return null;
    }
}
