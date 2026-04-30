using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlerConfig : MonoBehaviour
{
    [SerializeField] private ControlerMusic controlerMusic;
    [Header("Options Camps")]
    [SerializeField] private Slider sliderVolume;
    void Start() {
        sliderVolume.onValueChanged.AddListener(OnSliderVolume);

        //Update Values
        sliderVolume.value = GameManager.gameManager.Volume;
    }
    void OnDisable() {
        GameManager.gameManager.SaveConfig();
    }

    #region Sliders Listener
    void OnSliderVolume(float value) {
        GameManager.gameManager.Volume = value;
        controlerMusic.UpdateVolume(value);
    }
    #endregion
}
