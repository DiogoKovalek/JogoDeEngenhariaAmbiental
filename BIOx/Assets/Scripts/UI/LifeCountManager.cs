using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeCountManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lifeText;

    public void OnUpdateTextLife() {
        lifeText.text = "X" + ManagerAtributes.life.ToString();
    }
}
