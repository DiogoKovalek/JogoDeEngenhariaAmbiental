using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    private float timeForActiveItem = 0.3f;
    private Transform oldParent; // Para voltar a sua lista de origem
    [SerializeField] private TypeItem typeItem;
    [SerializeField] private GameObject shadown;
    void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public void GetThisItem(PlayerManageItem playerMI) {
        shadown?.SetActive(false);
        boxCollider.enabled = false;
        oldParent = this.transform.parent;
        playerMI.GetItem(transform);
    }
    public void DropThisItem() {
        shadown?.SetActive(true);
        transform.SetParent(oldParent);
        StartCoroutine(delayActiveItem());
    }
    public TypeItem GetTypeItem() {
        return typeItem;
    }

    private IEnumerator delayActiveItem() {
        yield return new WaitForSeconds(timeForActiveItem);
        boxCollider.enabled = true;
    }

}