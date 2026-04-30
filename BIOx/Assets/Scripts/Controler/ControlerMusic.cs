using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerMusic : MonoBehaviour
{
    private AudioSource audioSource;
    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    void Start() {
        //Apply all configs
        UpdateVolume(GameManager.gameManager.Volume);
    }
    public void UpdateVolume(float value) {
        audioSource.volume = value;
    }
}
