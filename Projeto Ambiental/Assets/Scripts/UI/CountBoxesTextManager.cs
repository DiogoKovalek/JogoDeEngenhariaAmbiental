using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountBoxesTextManager : MonoBehaviour
{
    /*
    ===================================================================================
    CountBoxesTextManager tem o objetivo de controlar o texto na UI que mostra quantas 
    caixas existe na fase e quantas o jogador ja entregou

    -> OnUpdateBoxesInfo(byte boxCollect, byte boxInGame) Ligado a Evento. Tem a 
    funcao de atualizar o texto da UI informando os novos valores de caixas
    ===================================================================================
    */

    [SerializeField] private TextMeshProUGUI textCamp;

    public void OnUpdateBoxesInfo(byte boxCollect, byte boxInGame) {
        textCamp.text = new string(boxCollect + "/" + boxInGame);
    }
}
