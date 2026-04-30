using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameManager : MonoBehaviour {
    public static GameManager gameManager;

    [Header("Config")]
    public float Volume;

    #region Class Serializable
    [System.Serializable]
    class ConfigData {
        public float Volume;
    }
    [System.Serializable]
    class ScoreData {
        public String[] namePlacar = new string[10];
        public int[] pointsPlacar = new int[10];
    }
    #endregion

    void Awake() {
        if(gameManager == null) {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

        LoadConfig();
    }
    #region Config

    #endregion

    #region Saves/Loads
    public void SaveConfig() {
        String pathConfig = Application.persistentDataPath + "/config.json";

        ConfigData configData = new ConfigData {
            Volume = this.Volume
        };

        String json = JsonUtility.ToJson(configData);

        File.WriteAllText(pathConfig, json);
        Debug.Log(pathConfig);
    }
    public void LoadConfig() {
        String pathConfig = Application.persistentDataPath + "/config.json";

        if (File.Exists(pathConfig)) {
            String json = File.ReadAllText(pathConfig);
            ConfigData configData = JsonUtility.FromJson<ConfigData>(json);

            Volume = configData.Volume;
        }
    }

    public void SaveScore() {
        String pathScore = Application.persistentDataPath + "Scores/scores.json";
    }
    public void LoadScore() {
        String pathScore = Application.persistentDataPath + "Scores/scores.json";
    }
    #endregion
}
