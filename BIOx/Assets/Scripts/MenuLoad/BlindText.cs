using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlindText : MonoBehaviour
{
    /*
    =======================================================
    BlindText tem a funcao de piscar o texto
    =======================================================
    */
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float bps = 1f; // Blind per second
    public bool isBlind = true;
    void Start()
    {
        StartCoroutine(blind());
    }

    private IEnumerator blind() {
        while(isBlind){
            yield return new WaitForSeconds(1/bps/2);
            text.enabled = !text.IsActive();
        }
    }
}
