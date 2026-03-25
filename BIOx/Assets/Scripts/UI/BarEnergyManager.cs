using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarEnergyManager : MonoBehaviour
{
    /*
    ================================================================================
    BarEnergyManager tem como funcionalidade gerenciar a barra de energia da
    fase

    -> OnUpdateBarEnergy() Ligado a Evento. Para atualizar o preenchimento da barra
    ================================================================================
    */
    [SerializeField] private RectTransform iconEnergy;
    [SerializeField] private RectTransform contentEnergy;
    private float[] posYBetween = {0, 420};
    
    public void OnUpdateBarEnergy(float percent) {
        float pos = posYBetween[0] + (posYBetween[1] - posYBetween[0])*((100 - percent)/100);
        iconEnergy.anchoredPosition = new Vector2(0, - pos);
        contentEnergy.offsetMax = new Vector2(contentEnergy.offsetMax.x, - pos);
    }
}