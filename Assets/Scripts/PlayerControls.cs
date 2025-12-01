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
    private Animator _animator;

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
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (canmove) 
        {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        }

        FlipSprite();
        HandleAnimation();
    }


    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value) {
    
        if (IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            logic.jumpsound();
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
    private void FlipSprite()
    {
        bool playerHasSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        if (playerHasSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.linearVelocity.x), transform.localScale.y);
        }
    }
    void HandleAnimation()
    {
        _animator.SetFloat("mag", moveInput.sqrMagnitude);
        _animator.SetFloat("HorizontalMovement", moveInput.x);
    }
}