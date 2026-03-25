using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoManager : MonoBehaviour
{
    /*
    =========================================================================
    LevelInfoManager tem a funcao de gerenciar o painel de LevelInfo

    Ligados a eventos
    -> OnStartGameScreen(String level, float timeShowText) tela de iniciar o jogo
    -> OnShowGameOverScreen()
    -> OnShowLevelCompleteScreen()
    =========================================================================
    */

    [SerializeField] private Image blackScreen;
    [SerializeField] private TextMeshProUGUI text;
    private float alpha = 1;
    private Coroutine actionLerp;
    private float timeDeleyLerp = 0.01f;


    private Color corBranca = Color.white;
    private Color corVermelha = new Color32(234, 50, 60, 255);
    private Color corVerde = new Color32(211, 252, 126, 255);
    /*
    public void OnBrightenScreen() {
        if (actionLerp == null) {
            actionLerp = StartCoroutine(lerpAlpha(-1));
        }
    }
    public void OnDarkenScreen() {
        if (actionLerp == null) {
            actionLerp = StartCoroutine(lerpAlpha(1));
        }
    }
    public void OnShowTexLevel(String level) {
        textLevel.text = "Level " + level; 
    }

    public void OnSetEnableLevelInfo(bool blackS, bool textL) {
        blackScreen.gameObject.SetActive(blackS);
        textLevel.gameObject.SetActive(textL);
    }
    */

    public void OnStartGameScreen(String level, float timeShowText) {
        if(actionLerp == null) {
            actionLerp = StartCoroutine(coroutineStartGameScreen(level, timeShowText));
        }   

    }
    private IEnumerator coroutineStartGameScreen(String level, float timeShowText) {
        blackScreen.gameObject.SetActive(true);
        StartCoroutine(lerpAlpha(-1));

        text.gameObject.SetActive(true);
        text.color = corBranca;
        text.text = "Level " + level;
        yield return new WaitForSeconds(timeShowText);

        text.gameObject.SetActive(false);
        blackScreen.gameObject.SetActive(false);
    }
    public void OnShowGameOverScreen() {
        if (actionLerp == null) {
                actionLerp = StartCoroutine(coroutineShowGameOverScreen());
        }
    }
    private IEnumerator coroutineShowGameOverScreen() {
        blackScreen.gameObject.SetActive(true);
        Color cor = blackScreen.color;
        cor.a = 0.5f;
        blackScreen.color = cor;

        text.gameObject.SetActive(true);
        text.color = corVermelha;
        text.text = "GAME OVER";
        yield return null;
    }
    public void OnShowLevelCompleteScreen() {
        if(actionLerp == null) {
            actionLerp = StartCoroutine(coroutineShowLevelCompleteScreen());
        }
    }
    private IEnumerator coroutineShowLevelCompleteScreen() {
        blackScreen.gameObject.SetActive(true);
        Color cor = blackScreen.color;
        cor.a = 0.5f;
        blackScreen.color = cor;

        text.gameObject.SetActive(true);
        text.color = corVerde;
        text.text = "LEVEL COMPLETE";
        yield return null;
    }
    private IEnumerator lerpAlpha(int direction) { //1 cresce   -1 deresce
        Color cor = blackScreen.color;
        if(direction == 1) alpha = 0;
        else if(direction == -1) alpha = 1;
        else yield break;
        cor.a = alpha;
        blackScreen.color = cor;
        for(int i = 0; i < 100; i++) {
            alpha += direction * 0.01f;
            cor.a = alpha;
            blackScreen.color = cor;
            yield return new WaitForSeconds(timeDeleyLerp);
        }
        actionLerp = null;
    }
}
