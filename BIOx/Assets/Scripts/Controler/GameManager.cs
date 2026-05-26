using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameManager : MonoBehaviour {
    public static GameManager gameManager;

    [Header("Config")]
    public float Volume;

    [Header("Points Placar")]
    public int[] pointsPlacar = new int[10];

    #region Class Serializable
    [System.Serializable]
    class ConfigData {
        public float Volume;
    }
    [System.Serializable]
    class ScoreData {
        public int[] pointsPlacar = new int[8];
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
        LoadScore();
    }
    #region Config

    #endregion

    #region Score
    public bool checkIfNewRecord(int points) {
        return points > pointsPlacar[7];
    }

    public void addNewRecord(int points) {
        if(!checkIfNewRecord(points)) return;

        int[] aux = new int[8];
        bool alocado = false;
        for(int i = 0; i < aux.Length; i++) {
            if (!alocado) {
                if (points > pointsPlacar[i]) {
                    aux[i] = points;
                    alocado = true;
                }
                else {
                    aux[i] = pointsPlacar[i];
                }
            }
            else {
                aux[i] = pointsPlacar[i - 1];
            }
        }
    }
    #endregion

    #region Saves/Loads
    public void SaveConfig() {
        String pathConfig = Application.persistentDataPath + "/config.json";

        ConfigData configData = new ConfigData {
            Volume = this.Volume
        };

        String json = JsonUtility.ToJson(configData);

        File.WriteAllText(pathConfig, json);
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

        ScoreData scoreData = new ScoreData {
            pointsPlacar = this.pointsPlacar
        };

        String json = JsonUtility.ToJson(scoreData);

        File.WriteAllText(pathScore, json);
    }
    public void LoadScore() {
        String pathScore = Application.persistentDataPath + "Scores/scores.json";

        if (File.Exists(pathScore)) {
            String json = File.ReadAllText(pathScore);
            ScoreData scoreData = JsonUtility.FromJson<ScoreData>(json);

            pointsPlacar = scoreData.pointsPlacar;
        }
    }
    #endregion
}
