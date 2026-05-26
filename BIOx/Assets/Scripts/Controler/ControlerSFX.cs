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
    [SerializeField] private AudioClip SFXLifeUp;
    [SerializeField] private AudioClip SFXDamage;

    void Start() {
       audioSource.volume = GameManager.gameManager.Volume; 
    }
    public void OnPlaySFX(SFXSound sound) {
        switch (sound) {
            case SFXSound.COIN:
                audioSource.PlayOneShot(SFXCoin);
                break;
            default:
            case SFXSound.LIFE:
                audioSource.PlayOneShot(SFXLifeUp);
                break;
            case SFXSound.DAMAGE:
                audioSource.PlayOneShot(SFXDamage);
                break;
        }
    }
}


public enum SFXSound {
    COIN,
    LIFE,
    DAMAGE
}