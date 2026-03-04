using System;
using UnityEngine.SceneManagement;

public static class ManagerScenes
{
    private static String[] SceneLevels = {"W0L1", "W0L2", "W0L3"};
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