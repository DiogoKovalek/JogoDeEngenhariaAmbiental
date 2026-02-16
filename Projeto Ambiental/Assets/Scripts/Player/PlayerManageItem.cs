using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManageItem : MonoBehaviour
{
    /*
    =======================================================
    PlayerManageItem tem o objetivo de gerenciar os items 
    que o player segura

    -> GetItem(Transform item) pega o item em questao
    -> DropItem() dropa/joga o item que segura
    -> DepositeItem() o item que o jogador esta segurando
    e depositado no Interactive
    -> GetTypeItem() retorna o tipo do item
    -> CheckIfIsLoadingItem() verifica se o player segura 
    um item
    =======================================================
    */
    private Player player;
    [SerializeField] private Transform handForItem;
    private ItemBehaviour item;
    private TypeItem typeItem;

    void Awake() {
        player = GetComponent<Player>();
    }

    public void GetItem(Transform item) {
        this.item = item.gameObject?.GetComponent<ItemBehaviour>();
        typeItem = this.item.GetTypeItem();
        this.item.transform.parent = handForItem;
        this.item.transform.position = handForItem.position;
    }
    public void DropItem() {
        if (item != null) {
            item.DropThisItem();
            resetItem();
        }
    }
    public void DepositItem() {
        if(item != null) {
            //Por Enquanto e so um
            player.UpdBoxesInControler(1);
            Destroy(item.gameObject);
            resetItem();
        }
    }
    public TypeItem GetTypeItem() {
        return typeItem;
    }
    public bool CheckIfIsLoadingItem() {
        return item != null;
    }


    private void resetItem() {
        item = null;
        typeItem = TypeItem.NONE;
    }
}
public enum TypeItem {
    NONE,
    BOX
}