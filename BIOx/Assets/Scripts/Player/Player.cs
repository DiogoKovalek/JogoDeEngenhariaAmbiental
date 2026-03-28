using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour {
    /*
    =================================================================================
    Player serve como um manager de todos as outras classes, então se
    uma classe prescisar se comunicar com outra, ela deve conversar 
    com Player.

    -> AddEnergyInTruck(int value) adiciona engergia no caminão para 
    depois esvaziar
    -> EmptyEnergy() metodo para tranformar todo valueEnergyInTruck
    para energia no pronta
    -> TakeDamage(int damage, float speedFore, Vector2 diretion) Serve para dar dano
    ao player, por padrao tira vida, mas se for especificado direcao, sera aplicado
    tambem um recuo e o drop do item que se carrega

    //In Controler
    -> UpdEnergyInControler(int valuer) adiciona ou decrementa Energia ao Controler
    -> UpdCoinInControler(int valuer) adiciona ou decrementa Coin ao Controler
    -> UpdPointInControler(int valuer) adiciona ou decrementa Point ao Controler

    //Get Component
    -> Geters de todos os components
    =================================================================================
    */
    private SpriteRenderer sprRen;
    private Animator anim;

    private bool isInvunerable = false;
    private bool isEndGame = false;
    private float timeForInvunerable = 0.5f;
    private float timeForTradeAlpha = 0.05f;
    private Color cor;
    //Events =========================================================
    public delegate void UpdatedPointInGame(int value);
    public event UpdatedPointInGame UpdatedPoint;
    public delegate void PlayedSfx(SFXSound sound);
    public event PlayedSfx PlayedSFX;
    //================================================================

    //Scripts ========================================================
    private ManagerCollideTriggers managerCollideTriggers;
    private MovePlayer movePlayer;
    private PlayerCommunicateCollectible playerCommunicateCollectible;
    private PlayerManageItem playerManageItem;
    private PlayerParticleManager playerParticle;
    //================================================================

    void Awake() {
        managerCollideTriggers = GetComponent<ManagerCollideTriggers>();
        movePlayer = GetComponent<MovePlayer>();
        playerCommunicateCollectible = GetComponent<PlayerCommunicateCollectible>();
        playerManageItem = GetComponent<PlayerManageItem>();
        playerParticle = GetComponent<PlayerParticleManager>();

        sprRen = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        cor = sprRen.color;
    }

    # region Damage
    public void TakeDamage(int damage, float speedForce = 0, Vector2 direction = default) {
        if (!isInvunerable && !isEndGame) {
            //Piscar player
            StartCoroutine(Invunerable());
            if(direction != Vector2.zero) { //Recuo e Drop de item
                movePlayer.ApplyBoost(speedForce, direction);
                playerManageItem.DropItem();
            }
        }
        
    }
    private IEnumerator Invunerable() {
        isInvunerable = true;
        StartCoroutine(blinkWhileInvunerable());
        yield return new WaitForSeconds(timeForInvunerable);
        isInvunerable = false;
        managerCollideTriggers.DetectedEnemyBeforeInvunerable();
    }
    private IEnumerator blinkWhileInvunerable() {
        cor.a = cor.a == 0.3f ? 1.0f : 0.3f;
        sprRen.color = cor;
        yield return new WaitForSeconds(timeForTradeAlpha);
        if(isInvunerable) StartCoroutine(blinkWhileInvunerable());
        else {
            cor.a = 1.0f;
            sprRen.color = cor;
        }
    }
    #endregion
    #region For Controler
    public void UpdPointInControler(int value) {
        if(UpdatedPoint != null) UpdatedPoint(value);
    }
    public void PlaySFX(SFXSound sound) {
        if(PlayedSFX != null) PlayedSFX(sound);
    }
    #endregion

    #region Events
    public void OnPlayerLost() {
        // Animacao de perder

        isEndGame = true;
    }
    public void OnPlayerWin() {
        // Animacao de Ganhar

        isEndGame = true;
    }
    #endregion

    #region GetComponests
    public ManagerCollideTriggers GetManagerCollideTriggers() {
        return managerCollideTriggers;
    }
    public MovePlayer GetMovePlayer() {
        return movePlayer;
    }
    public PlayerCommunicateCollectible GetPlayerCommunicateCollectible() {
        return playerCommunicateCollectible;
    }
    public PlayerManageItem GetPlayerManageItem() {
        return playerManageItem;
    }
    public PlayerParticleManager GetManageSmoke(){
        return playerParticle;
    }
    public Animator GetAnimator() {
        return anim;
    }
    public SpriteRenderer GetSpriteRenderer() {
        return sprRen;
    }
    #endregion
}
