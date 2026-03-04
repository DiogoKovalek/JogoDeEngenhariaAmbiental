using System;

public static class ManagerAtributes
{
    /*
    ==============================================
    ManagerAtributes tem a funcao de armazenar e
    passar dados de uma scena para outra

    -> ResetAtributesForGame() reseta os atributos
    essenciais para um novo jogo
    -> ResetCacheAtributes() reseta os atributos
    cache
    ==============================================
    */

    // In Game
    public static int points = 0;
    public static int level = 1;

    
    // In Level
    public static int cachePoints = 0;
    public static int cacheBonusPoint = 0;
    // In Save
    public static int[] pointsPlacar = new int[10];
    public static String[] namePlaar = new string[10];

    public static void ResetAtributesForGame() {
        points = 0;
        level = 1;
        ResetCaheAtributes();
    }

    public static void ResetCaheAtributes() {
        cachePoints = 0;
        cacheBonusPoint = 0;
    }
}
