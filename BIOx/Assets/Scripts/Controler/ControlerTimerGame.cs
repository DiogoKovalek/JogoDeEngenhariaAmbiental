using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class ControlerTimerGame : MonoBehaviour
{
    [SerializeField] private const byte timeStartGame = 100;
    private byte time = timeStartGame;

    private ControlerGame controlerGame;

    public delegate void UpdateStopwatch(int time);
    public event UpdateStopwatch UpdatedStopwatch;

    private bool timeStop = false;
    void Awake(){
        controlerGame = GetComponent<ControlerGame>();
    }
    public void initializeTime(){
        UpdatedStopwatch(time);
    }
    public void StartTimer() {
        StartCoroutine(stopwatch());
    }
    public void StopTime() {
        timeStop = true;
    }
    public void PlayTime() {
        timeStop = false;
    }

    private IEnumerator stopwatch() {
        while(timeStop) yield return null;
        yield return new WaitForSeconds(1f); // espera 1 segundo
        if(time == 0) controlerGame.TimeOver();
        else{
            time -= 1;
            UpdatedStopwatch(time);
            StartCoroutine(stopwatch());
        }
    }  
}
