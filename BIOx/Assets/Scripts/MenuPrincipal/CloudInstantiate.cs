using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudInstantiate : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private Sprite[] spritesCloud;
    [SerializeField] private Vector3 posEnd;

    private SpriteRenderer sprRen;

    void Awake(){
        sprRen = GetComponent<SpriteRenderer>();
    }
    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, posEnd, speed * Time.deltaTime);
        
        
        if(Vector2.Distance(transform.position, (Vector2) posEnd) < 0.01f){
            gameObject.SetActive(false);
        }
    }
    public void PassAttributes(float xEnd, int layer){
        posEnd = new Vector3(xEnd, transform.position.y, 0);
        sprRen.sortingOrder = layer;

        //Trade Sprite
        sprRen.sprite = spritesCloud[Random.Range(0, spritesCloud.Length-1)];
    }
}
