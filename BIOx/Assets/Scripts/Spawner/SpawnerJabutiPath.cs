using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerJabutiPath : MonoBehaviour
{
    [SerializeField] private bool AplicateNewVaribles = true;
    [SerializeField] private float speedJabut = 3;
    private EnemyMoveAtPoint[] jabutiList;
    private Transform[] points;

    void Awake() {
        jabutiList = transform.GetChild(0).GetComponentsInChildren<EnemyMoveAtPoint>();
        points = transform.GetChild(1).GetComponentsInChildren<Transform>().Skip(1).ToArray();

        /*
        Debug.Log(jabutiList.Length + " " + points.Length);

        foreach(var pos in points) {
            Debug.Log(pos.position.x + " " + pos.position.y);
        }
        */

        //Ageitar posicao dos jabuti
        foreach(var jabuti in jabutiList) {
            Vector2 posJabuti = jabuti.GetComponent<Transform>().position;
            int index = 0;
            Vector2 near = points[index].position;
            float dist = Vector2.Distance(near, posJabuti);
            for(int i = 1; i < points.Length; i++) {
                int newIndex = i;
                Vector2 newPos = points[newIndex].position;
                float newDistance = Vector2.Distance(newPos, posJabuti);
                if(newDistance < dist) {
                    near = newPos;
                    dist = newDistance;
                    index = newIndex;
                }
                if(dist == 0) break;
            }

            jabuti.GetComponent<Transform>().position = near;
            jabuti.AtributeControler(this);
            index++;
            jabuti.initAtributesForMove(points[index].position, index);
        }
    }

    void Start() {
        if (AplicateNewVaribles) {
            foreach(var jabuti in jabutiList) {
                jabuti.SetSpeed(speedJabut);
            }
        }
    }
    public Vector2 GetTargetByIndex(ref int index) {
        if(index >= points.Length) index = 0;
        return points[index].position;
    }
}
