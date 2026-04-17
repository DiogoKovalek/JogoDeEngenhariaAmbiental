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
    [Header("Canvas")]
    [SerializeField] private GameObject MenuOptions;
    [SerializeField] private GameObject ButtonOpenOptions;
    [SerializeField] private GameObject ButtonStartGame;
    public void BTPlay() {
        ManagerAtributes.ResetAtributesForGame();
        ManagerScenes.SceneToLevel(1);
        Debug.Log("Play");
    }
    public void BTOpenOptions(){
        MenuOptions.SetActive(true);
        ButtonOpenOptions.SetActive(false);
        ButtonStartGame.SetActive(false);
    }
    public void BTExitOptions(){
        MenuOptions.SetActive(false);
        ButtonOpenOptions.SetActive(true);
        ButtonStartGame.SetActive(true);
    }
    public void BTExit() {
        Debug.Log("Sair Do Jogo");
        Application.Quit();
    }
}
