using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2d;
    private float _horizontalMovement;
    public float Speed = 10f;
    public float JumpForce = 10f;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
   
    void Start() 
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (_horizontalMovement < 0) {

            _spriteRenderer.flipX = true;
        }
        else if (0 < _horizontalMovement) {

            _spriteRenderer.flipX = false;
        }

        if (Input.GetButton("Jump")) {

            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, JumpForce);
        }

        _animator.SetBool("isMoving", _horizontalMovement != 0);

    }

    private void FixedUpdate()
    {
        _rigidbody2d.velocity = new Vector2( _horizontalMovement * Speed, _rigidbody2d.velocity.y );
    }
}