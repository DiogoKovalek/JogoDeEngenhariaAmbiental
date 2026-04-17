using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransform : MonoBehaviour
{
    [SerializeField] private Transform object1;
    [SerializeField] private Transform object2;
    [SerializeField] private DIRECTION_BAR direction_bar;
    [SerializeField] private float speed = 20;
    private int direction; // -1 left   1 right
    private Vector2 initPos1, initPos2;

    void Start()
    {
        if (direction_bar == DIRECTION_BAR.LEFT) direction = -1;
        else direction = 1;
        //Teste de qual vem primeiro
        if(direction == -1 && object1.position.x > object2.position.x) {
            Transform aux = object2;
            object2 = object1;
            object1 = aux;
        }
        initPos1 = object1.position;
        initPos2 = object2.position;
    }

    void Update()
    {
        object1.position = Vector2.MoveTowards(object1.position, new Vector2(direction * initPos2.x, initPos2.y), Time.deltaTime*speed);
        object2.position = Vector2.MoveTowards(object2.position, new Vector2(initPos1.x, initPos1.y), Time.deltaTime*speed);

        if (object1.position.x <= direction * initPos2.x) {
            Transform aux = object2;
            object2 = object1;
            object1 = aux;

            object2.position = initPos2;
        }
    }

}

