using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class ControlerTimerGame : MonoBehaviour
{
    [SerializeField] private const byte timeStartGame = 255;
    private byte time = timeStartGame;

    private ControlerGame controlerGame;

    public delegate void UpdateStopwatch(int time);
    public event UpdateStopwatch UpdatedStopwatch;
    void Awake(){
        controlerGame = GetComponent<ControlerGame>();
    }
    public void initializeTime(){
        UpdatedStopwatch(time);
    }
    public void StartTimer() {
        StartCoroutine(stopwatch());
    }

    private IEnumerator stopwatch() {
        yield return new WaitForSeconds(1f); // espera 1 segundo
        if(time == 0) controlerGame.GameOver();
        else{
            time -= 1;
            UpdatedStopwatch(time);
            StartCoroutine(stopwatch());
        }
    }  
}
