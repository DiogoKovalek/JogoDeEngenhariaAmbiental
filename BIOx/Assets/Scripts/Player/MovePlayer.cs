using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private bool isRun = true;
    private Player player;
    private PlayerParticleManager playerParticle;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 boost;
    private float forceMultiplier = 10f;
    private Coroutine corrotineReduceBoost;
    private Vector2 vectorMovement;
    private float distPoint = 0;
    private static readonly float[] speedVariation = { 0.0f, 3.5f, 7f };
    private static readonly float[] distanceVariation = { 0.3f, 2.3f };

    [SerializeField] private InputMode inputMode = InputMode.Mobile;
    private System.Action currentInput;
    void Awake()
    {
        player = GetComponent<Player>();
        input = ManagerInputs.inputPlayer;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        anim = player.GetAnimator();
        playerParticle = player.GetManageSmoke();

        if (inputMode == InputMode.Mobile)
        {
            currentInput = mobileInput;
        }
        else if (inputMode == InputMode.Keyboard)
        {
            currentInput = keyboardInput;
        }
    }

    void Update()
    {
        currentInput?.Invoke();

        anim.SetFloat("MoveX", moveInput.x);
        anim.SetFloat("MoveY", moveInput.y);
        anim.SetFloat("Speed", moveInput.magnitude);
    }
    void FixedUpdate()
    {
        vectorMovement = moveInput * speed;
        rb.velocity = vectorMovement + boost;

        if (isRun) playerParticle.UpdateSmokeDirection(moveInput);
    }
    public void ApplyBoost(float force, Vector2 direction)
    {
        boost = force * forceMultiplier * direction;
        if (corrotineReduceBoost == null) corrotineReduceBoost = StartCoroutine(reduceBoost());
    }
    private IEnumerator reduceBoost()
    {
        while (boost.magnitude > 0.01f)
        {
            yield return new WaitForFixedUpdate();
            boost = Vector2.Lerp(boost, Vector2.zero, 10f * Time.fixedDeltaTime);
        }
        boost = Vector2.zero;
        corrotineReduceBoost = null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceVariation[0]);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanceVariation[1]);
    }
    private void OnClick()
    {
        Vector2 screenPos = input.Game.Position.ReadValue<Vector2>();
        screenPos = (Vector2)Camera.main.ScreenToWorldPoint(screenPos);
        distPoint = Vector2.Distance(screenPos, (Vector2)transform.position);
        moveInput = (screenPos - (Vector2)transform.position).normalized;

        if (distPoint >= distanceVariation[1])
        {
            speed = speedVariation[2];
        }
        else if (distPoint >= distanceVariation[0])
        {
            speed = speedVariation[1];
        }
        else
        {
            speed = speedVariation[0];
        }

        if (speed > speedVariation[1] && !playerParticle.IsSmokeRun())
        {
            playerParticle.StartSmoke();
        }
        else if (speed <= speedVariation[1] && playerParticle.IsSmokeRun())
        {
            playerParticle.StopSmoke();
        }
    }
    private void mobileInput()
    {
        if (input.Game.Click.IsPressed())
        {
            OnClick();
        }
        else
        {
            moveInput = Vector2.zero;
            if (playerParticle.IsSmokeRun()) playerParticle.StopSmoke();
        }
    }

    private void keyboardInput()
    {
        moveInput = input.Game.Move.ReadValue<Vector2>();
        if (moveInput.magnitude >= 0.9 && !playerParticle.IsSmokeRun())
        {
            playerParticle.StartSmoke();
        }
        else if (moveInput.magnitude < 0.9 && playerParticle.IsSmokeRun())
        {
            playerParticle.StopSmoke();
        }
    }
}

enum InputMode
{
    Mobile,
    Keyboard
}