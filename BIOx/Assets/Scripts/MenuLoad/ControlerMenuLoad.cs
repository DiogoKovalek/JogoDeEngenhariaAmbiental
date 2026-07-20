using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class ControlerMenuLoad : MonoBehaviour
{

    /*
    ================================================================
    ControlerMenuLoad tem a funcao de controlar o menu de troca de 
    fase

    -> PresButtonNextLevel() Funcao para botao de troca de fase
    ================================================================
    */
    
    [SerializeField] private GameObject LevelComplete;
    [SerializeField] private GameObject CliqueParaContinuar;
    [SerializeField] private GameObject PointsText;
    [SerializeField] private GameObject PointsTextBonus;
    [SerializeField] private GameObject ButtonNextLevel;

    [Header("Question")]
    [SerializeField] private GameObject ScreenQuestion;
    [SerializeField] private GameObject TextQuestion;
    [SerializeField] private GameObject[] Options;
    [SerializeField] private GameObject CorrectPoints;
    private bool isInQuestionScreen;
    private Color32 colorButtonCorrect = new Color32(41,140,15,255);
    private Color32 colorButtonIncorrect = new Color32(140,16,20,255);
    [Header("Music")]
    [SerializeField] private AudioSource musicSource;

    [Header("SFX")]
    [SerializeField] private AudioSource audioSFX;
    [SerializeField] private AudioClip SFXPoints;

    private TextMeshProUGUI textPointsText;
    private TextMeshProUGUI textPointsBonusText;
    private int loops = 75;

    private int totalPoints = ManagerAtributes.points;
    private int pointForAdd = ManagerAtributes.cachePoints;
    private int pointBonusForAdd= ManagerAtributes.cacheBonusPoint;
    private int countPoints;
    void Start()
    {
        textPointsText = PointsText.GetComponent<TextMeshProUGUI>();
        textPointsBonusText = PointsTextBonus.GetComponent<TextMeshProUGUI>();
        StartCoroutine(viewQuestionari());
        musicSource.volume = GameManager.gameManager.Volume;
        audioSFX.volume = GameManager.gameManager.Volume;
    }

    private IEnumerator viewQuestionari() {
        yield return new WaitForSeconds(1f);
        ScreenQuestion.SetActive(true);
        isInQuestionScreen = true;

        string[] question = ManagerQuestions.SortRandomQuest().Split(";;");
        List<string> optionsString = new List<string>();
        for(int i = 1; i < question.Length; i++) optionsString.Add(question[i]);

        TextQuestion.GetComponent<TextMeshProUGUI>().text = question[0];
        for(int i = 0; i < Options.Length; i++) {
            if(optionsString.Count == 0) {
                Options[i].GetComponentInChildren<TextMeshProUGUI>().text = "ERRO";
                continue;
            }
            int index = Random.Range(0, optionsString.Count);
            Options[i].GetComponentInChildren<TextMeshProUGUI>().text = optionsString[index];
            optionsString.RemoveAt(index);
        }

        while (isInQuestionScreen){
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        ScreenQuestion.SetActive(false);
        StartCoroutine(viewPoints());
    }

    private IEnumerator viewPoints() {
        yield return new WaitForSeconds(1f);

        LevelComplete.SetActive(true);
        yield return new WaitForSeconds(1f);

        PointsText.SetActive(true);
        countPoints = totalPoints;
        textPointsText.text = countPoints.ToString("D6");
        yield return new WaitForSeconds(0.5f);
        
        int sumPoints = totalPoints + pointForAdd;
        int sumPerWhile = pointForAdd/loops == 0 ? 1 : pointForAdd/loops;
        while(countPoints < sumPoints - sumPerWhile) {
            countPoints += sumPerWhile;
            textPointsText.text = countPoints.ToString("D6");
            audioSFX.PlayOneShot(SFXPoints);
            yield return new WaitForSeconds(0.01f);
        }
        
        // Como pointsForAdd e inteiro ele prescisa ser atualizado para o valor original, mesma coisa para bonus
        countPoints = sumPoints;
        textPointsText.text = countPoints.ToString("D6");
        yield return new WaitForSeconds(1f);

        if (pointBonusForAdd != 0) {
            PointsTextBonus.SetActive(true);
            textPointsBonusText.text = "Bonus: + " + pointBonusForAdd.ToString("D6");
            yield return new WaitForSeconds(1f);

            sumPoints += pointBonusForAdd;
            sumPerWhile = pointBonusForAdd/loops == 0 ? 1 : pointBonusForAdd/loops; // verificacao caso o bonus seja menor que loops
            while (countPoints < sumPoints - sumPerWhile) {
                countPoints += sumPerWhile;
                textPointsText.text = countPoints.ToString("D6");
                audioSFX.PlayOneShot(SFXPoints);
                yield return new WaitForSeconds(0.01f);
            }

            countPoints = sumPoints;
            textPointsText.text = countPoints.ToString("D6");
            yield return new WaitForSeconds(1f);
        }
        CliqueParaContinuar.SetActive(true);
        ButtonNextLevel.SetActive(true);

        ManagerAtributes.points = countPoints;
    }

    public void PresButtonNextLevel() {
        ManagerAtributes.level += 1;
        ManagerScenes.SceneToLevel(ManagerAtributes.level);
    }

    public void PresButtonAlternative(int num) {
        isInQuestionScreen = false;
        bool isCorrect = ManagerQuestions.CheckeedIfCorrect(Options[num - 1].GetComponentInChildren<TextMeshProUGUI>().text);
        if (isCorrect) {
            Options[num - 1].GetComponent<Image>().color = colorButtonCorrect;
            CorrectPoints.SetActive(true);
            pointForAdd += 1000;
        }
        else {
            Options[num - 1].GetComponent<Image>().color = colorButtonIncorrect;
            for(int i = 0; i < Options.Length; i++) {
                if (ManagerQuestions.CheckeedIfCorrect(Options[i].GetComponentInChildren<TextMeshProUGUI>().text)) {
                    Options[i].GetComponent<Image>().color = colorButtonCorrect;
                    break;
                }
            }
        }
    }
}


