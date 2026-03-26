using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StopwatchManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCamp;

    public void OnUpdateStopwatch(int time){
        textCamp.text = time.ToString("D3");
    }
}
