using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    /*
    =====================================================================
    Move Player tem como finalidade fazer a movimentação do player
    =====================================================================
    */
    private InputPlayer input;
    private Vector2 moveInput;
    private float speed = 5.0f;
    private Rigidbody2D rb;
    void Awake() {
        input = new InputPlayer();
        input.Enable();

        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveInput = input.Game.Move.ReadValue<Vector2>();
    }
    void FixedUpdate() {
        rb.velocity = moveInput * speed;
    }
}
