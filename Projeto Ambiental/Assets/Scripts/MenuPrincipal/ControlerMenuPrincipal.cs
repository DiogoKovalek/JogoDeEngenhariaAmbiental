using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlerMenuPrincipal : MonoBehaviour
{
    /*
    ===========================================================
    ControlerMenuPrincipal tem o objetivo De controlar as acoes
    do menu pricipal

    -> BTPlay() acao do botao play

    -> BTOptions() acao do botao options

    -> BTExit() acao do botao exit
    ===========================================================
    */
    [SerializeField] String scenePlay;
    public void BTPlay() {
        SceneManager.LoadScene(scenePlay);
    }
    public void BTOptions(){
        Debug.Log("Options");
    }
    public void BTExit() {
        Debug.Log("Sair Do Jogo");
        Application.Quit();
    }
}
