using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    /*
    =====================================================================
    Move Player tem como finalidade fazer a movimentação do player

    -> ApplyBoost(float speedForce, Vetor2 direction)
    =====================================================================
    */
    private InputPlayer input;
    private Vector2 moveInput;
    private float speed = 5.0f;
    private Player player;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 directionAnimation = Vector2.zero;
    private Vector2 boost;
    private float forceMultiplier = 10f;
    private Coroutine corrotineReduceBoost;
    private Vector2 vectorMovement;
    void Awake() {
        player = GetComponent<Player>();
        input = ManagerInputs.inputPlayer;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start() {
        anim = player.GetAnimator();       
    }
    void Update()
    {
        moveInput = input.Game.Move.ReadValue<Vector2>();
        anim.SetFloat("MoveX", moveInput.x);
        anim.SetFloat("MoveY", moveInput.y);
        anim.SetFloat("Speed", moveInput.magnitude);
    }
    void FixedUpdate() {
        vectorMovement = moveInput * speed;
        rb.velocity = vectorMovement + boost;
    }
    public void ApplyBoost(float force, Vector2 direction) {
        boost = force * forceMultiplier * direction;
        if(corrotineReduceBoost == null) corrotineReduceBoost = StartCoroutine(reduceBoost());
    }
    private IEnumerator reduceBoost() {
        while (boost.magnitude > 0.01f){
            yield return new WaitForFixedUpdate();
            boost = Vector2.Lerp(boost, Vector2.zero, 10f*Time.fixedDeltaTime);
        }
        boost = Vector2.zero;
        corrotineReduceBoost = null;
        
    }
}
