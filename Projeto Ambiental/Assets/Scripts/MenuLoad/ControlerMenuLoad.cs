using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.LowLevel;

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
        StartCoroutine(view());
    }

    private IEnumerator view() {
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
}


