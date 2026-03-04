using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerSFX : MonoBehaviour
{
    /*
    ==================================================================
    ControlerSFX tem a funcao de controlar os efeitos sonoros
    ==================================================================
    */

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip SFXCoin;

    public void OnPlaySFX(SFXSound sound) {
        switch (sound) {
            case SFXSound.COIN:
                audioSource.PlayOneShot(SFXCoin);
                break;
            default:
                break;
        }
    }
}

public enum SFXSound {
    COIN
}