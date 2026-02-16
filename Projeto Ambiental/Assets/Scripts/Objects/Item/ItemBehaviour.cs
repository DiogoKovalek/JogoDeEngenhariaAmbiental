using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    /*
    ==============================================================
    ItemBehaviour tem o objetivo de defir o comportamento basico 
    de um item. Isso e necessario para diferenciar comportamento
    basico de especifico

    -> GetThisItem(PlayerManagerItem playerMI) serve para pegar o
    item
    -> DropThisItem() serve para dropar o item
    -> GetTypeItem() tem a funcao de pegar o tipo do item
    ==============================================================
    */
    private BoxCollider2D boxCollider;
    [SerializeField] private TypeItem typeItem;
    void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public void GetThisItem(PlayerManageItem playerMI) {
        boxCollider.enabled = false;
        playerMI.GetItem(transform);
    }
    public void DropThisItem() {
        boxCollider.enabled = true;
    }
    public TypeItem GetTypeItem() {
        return typeItem;
    }
}