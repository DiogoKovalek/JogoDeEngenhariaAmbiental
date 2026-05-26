using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlerGameOverScreen : MonoBehaviour
{
    /*
    ===========================================================
    ControlerGameOverScreen tem a funcao de controlar a tela
    de game over

    -> PresButtonBackMenu() funcao para botao voltar ao menu
    ===========================================================
    */

    [SerializeField] private GameObject SeusPontos;
    [SerializeField] private GameObject PointsText;
    [SerializeField] private GameObject CliqueParaVoltar;
    [SerializeField] private GameObject ButtonBackHome;
    [SerializeField] private GameObject NewRecord;
    [SerializeField] private GameObject PlacarPontos;
    [SerializeField] private GameObject NovosJogosEmBreve;
    [Header("Music")]
    [SerializeField] private AudioSource musicSource;
    [Header("SFX")]
    [SerializeField] private AudioSource audioSFX;
    [SerializeField] private AudioClip SFXPoints;
     
    private TextMeshProUGUI textPoints;
    private int loops = 75;

    private int totalPoints = ManagerAtributes.points;
    private int countPoints = 0;

    void Start() {
        textPoints = PointsText.GetComponent<TextMeshProUGUI>();
        musicSource.volume = GameManager.gameManager.Volume;
        audioSFX.volume = GameManager.gameManager.Volume;
        StartCoroutine(view());
    }
    private IEnumerator view() {
        yield return new WaitForSeconds(1f);
        
        SeusPontos.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        PointsText.SetActive(true);
        textPoints.text = countPoints.ToString("D6");
        yield return new WaitForSeconds(1f);

        int sumPerWhile = totalPoints/loops == 0 ? 1 : totalPoints/loops;
        while(countPoints < totalPoints - sumPerWhile) {
            countPoints += sumPerWhile;
            textPoints.text = countPoints.ToString("D6");
            audioSFX.PlayOneShot(SFXPoints);
            yield return new WaitForSeconds(0.01f);
        }

        countPoints = totalPoints;
        textPoints.text = countPoints.ToString("D6");
        yield return new WaitForSeconds(1f);

        CliqueParaVoltar.SetActive(true);
        ButtonBackHome.SetActive(true);
    }
    public void PresButtonBackMenu() {
        ManagerScenes.SceneToMenuInicial();
    }
}
