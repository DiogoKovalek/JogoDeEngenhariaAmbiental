using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ControlerBoxes : MonoBehaviour
{
    /*
    =================================================================
    ControlerBoxes tem como objetivo contar e controlar os numeros de
    caixas dentro da fase

    -> CountBoxes() inicia a contagem das caixas, serve para iniciar
    o jogo
    -> OnUpdateBoxesCollect(byte value) Ligado a Evento. Tem a funcao
    de atualiza o valor de caixas coletadas para + value. Depois
    atualiza a UI 
    =================================================================
    */
    [SerializeField] private GameObject listBoxes;

    private byte boxCollect = 0;
    private byte boxInGame = 0;

    //Events ================================================================
    public delegate void UpdatedBoxesCollect(byte boxCollect, byte boxInGame);
    public event UpdatedBoxesCollect UpdatedBox;
    //=======================================================================
    
    public void CountBoxes() {
        //Futuramente pode trocar ItemBehaviour por um Script de BOX, so nao vejo necessidade
        //de criar BOX no momento
        ItemBehaviour[] boxes = listBoxes.transform.GetComponentsInChildren<ItemBehaviour>();
        boxInGame = (byte) boxes.Length;
        UpdatedBox(boxCollect, boxInGame);
    }

    #region Events
    public void OnUpdateBoxesCollect(byte value) {
        boxCollect += value;
        if(UpdatedBox != null) UpdatedBox(boxCollect, boxInGame);
    }
    #endregion
}
