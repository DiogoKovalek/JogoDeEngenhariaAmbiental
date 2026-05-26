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
    //Const
    private const int initialLife = 3;
    public const int multiplierBonus = 2;
    // In Game
    public static int points = 0;
    public static int level = 1;
    public static int life = initialLife;
    
    // In Level
    public static int cachePoints = 0;
    public static int cacheBonusPoint = 0;


    public static void ResetAtributesForGame() {
        points = 0;
        level = 1;
        life = initialLife;
        ResetCaheAtributes();
    }

    public static void ResetCaheAtributes() {
        cachePoints = 0;
        cacheBonusPoint = 0;
    }
}
