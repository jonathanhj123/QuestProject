using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;
    private Vector2 moveInput;
    private bool isJumping = false;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    public bool canmove = false;
    private LogicScript logic;
    



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void FixedUpdate()
    {
        if (canmove) 
        {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        } 
    }


    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value) {
    
        if (IsGrounded())
        {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {

        if (col != null)
        {
            return col.IsTouchingLayers(groundLayer.value);
        }

        Vector2 origin = (Vector2)transform.position + Vector2.down * 0.1f;
        return Physics2D.OverlapCircle(origin, 0.12f, groundLayer) != null;
    }

    public void canMove()
    {
        canmove = true;
    }
}