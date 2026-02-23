using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    /*
    =============================================================
    RandomSprite tem a funcao de atribuir um sprite fisico 
    diferente para o objeto
    =============================================================
    */
    [SerializeField] private Sprite[] listSprites;

    void Start() {
        SpriteRenderer sprRen = GetComponent<SpriteRenderer>();
        sprRen.sprite = listSprites[Random.Range(0,listSprites.Length)];
    }
}
