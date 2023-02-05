using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    public bool canMove;

    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private Animator anim;

    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        anim = GetComponent <Animator>();
    }

    void Update()
    {
        CheckCanMove();
        if (canMove)
        {
            movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
        
        anim.SetFloat("speed", rb.velocity.magnitude);
        
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.velocity = movementDirection * speed;
        }
    }

    public void CheckCanMove()
    {
        canMove = GameManager.Instance.gameState == GameManager.GameState.Playing;
    }
}
