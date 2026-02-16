using TMPro;
using UnityEngine;

public class PointsTextManager : MonoBehaviour
{
    /*
    ================================================================
    PointsManager tem o objetivo de controlar o texto para exibir
    quantos ponto o jogador fez

    -> OnUpdatePointsText(int points) Ligado a Evento. Para mudar
    o valor da pontuacao
    ================================================================
    */
    [SerializeField] private TextMeshProUGUI textCamp;

    public void OnUpdatePointsText(int points){
        textCamp.text = points.ToString("D6");
    }
}