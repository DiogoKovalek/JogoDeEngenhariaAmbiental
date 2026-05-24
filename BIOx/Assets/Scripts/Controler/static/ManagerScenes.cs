using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public static class ManagerScenes
{
    private static String[] SceneLevels = {"W1L1", "W1L2", "W1L3"};
    private static String SceneMenuInicial = "MenuInicial";
    private static String SceneLoadScreen = "LoadScreen";
    private static String SceneGameOver = "GameOverScreen";
    private static int numLevel = 0;

    public static void SceneToLevel(int level) {
        int L = SceneLevels.Length;
        numLevel = level - 1 - (level-1)/L*L;
        ManagerAtributes.ResetCaheAtributes();
        SceneManager.LoadScene(SceneLevels[numLevel]);
    }
    public static void SceneToMenuInicial() {
        SceneManager.LoadScene(SceneMenuInicial);
    }
    public static void SceneToLoadScreen() {
        SceneManager.LoadScene(SceneLoadScreen);
    }
    public static void SceneToGameOver() {
        numLevel = 0;
        SceneManager.LoadScene(SceneGameOver);
    }
    public static void RestartLevel() {
        ManagerAtributes.ResetCaheAtributes();
        SceneManager.LoadScene(SceneLevels[numLevel]);
    }
}