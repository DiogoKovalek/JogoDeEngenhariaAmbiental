using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementBar : MonoBehaviour
{
    /*
    ================================================================
    MovementBar tem a funcionalidade de realizar movimento das 
    barras animadas no menu de load
    ================================================================
    */
    [SerializeField] private RectTransform bar1;
    [SerializeField] private RectTransform bar2;
    [SerializeField] private DIRECTION_BAR direction_bar;
    private int direction; // -1 left   1 right 
    private Vector2 initPos1, initPos2;
    [SerializeField] private float speed = 150f;
    

    void Start()
    {
        if (direction_bar == DIRECTION_BAR.LEFT) direction = -1;
        else direction = 1;
        //Teste de qual vem primeiro
        if(direction == -1 && bar1.anchoredPosition.x > bar2.anchoredPosition.x) {
            RectTransform aux = bar2;
            bar2 = bar1;
            bar1 = aux;
        }
        initPos1 = bar1.anchoredPosition;
        initPos2 = bar2.anchoredPosition;
    }

    void Update()
    {
        bar1.anchoredPosition = Vector2.MoveTowards(bar1.anchoredPosition, new Vector2(direction * initPos2.x, initPos2.y), Time.deltaTime*speed);
        bar2.anchoredPosition = Vector2.MoveTowards(bar2.anchoredPosition, new Vector2(initPos1.x, initPos1.y), Time.deltaTime*speed);

        if (bar1.anchoredPosition.x <= direction * initPos2.x) {
            RectTransform aux = bar2;
            bar2 = bar1;
            bar1 = aux;

            bar2.anchoredPosition = initPos2;
        }
    }
}

enum DIRECTION_BAR {
    LEFT
}
