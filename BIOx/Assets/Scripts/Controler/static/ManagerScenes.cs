using System;
using UnityEngine.SceneManagement;

public static class ManagerScenes
{
    private static String[] SceneLevels = {"W1L1", "W1L2", "W1L3","W1L4", "W1L5"};
    private static String SceneMenuInicial = "MenuInicial";
    private static String SceneLoadScreen = "LoadScreen";
    private static String SceneGameOver = "GameOverScreen";

    public static void SceneToLevel(int level) {
        int L = SceneLevels.Length;
        ManagerAtributes.ResetCaheAtributes();
        SceneManager.LoadScene(SceneLevels[level - 1 - (level-1)/L*L]);
    }
    public static void SceneToMenuInicial() {
        SceneManager.LoadScene(SceneMenuInicial);
    }
    public static void SceneToLoadScreen() {
        SceneManager.LoadScene(SceneLoadScreen);
    }
    public static void SceneToGameOver() {
        SceneManager.LoadScene(SceneGameOver);
    }
}