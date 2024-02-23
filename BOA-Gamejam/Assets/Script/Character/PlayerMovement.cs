using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rigidBody;
    public Animator animator;
    
    [Header("Blink Settings")] [SerializeField]
    public float blinkDistance;
    public float blinkTime;
    public bool canBlink = true;
    private float _blinkTimer;
    private bool _facingRight;
    private bool _facingUp;
    private Vector2 _movement;

    private void Blink()
    {
        Vector3 blink;
        if (_facingRight)
        {
            blink = new Vector3(blinkDistance, 0, 0);
        }
        else
        {
            blink = new Vector3(-blinkDistance, 0, 0);
        }
        if (_facingUp)
        {
            blink = new Vector3(0, blinkDistance, 0);
        }
        else
        {
            blink = new Vector3(0, -blinkDistance, 0);
        }
        if (_facingUp && _facingRight)
        {
            blink = new Vector3(blinkDistance, blinkDistance, 0);
        }
        else if(_facingUp && !_facingRight)
        {
            blink = new Vector3(-blinkDistance, blinkDistance, 0);
        } 
        else if(!_facingUp && _facingRight)
        {
            blink = new Vector3(blinkDistance, -blinkDistance, 0);
        }
        else if(!_facingUp && !_facingRight)
        {
            blink = new Vector3(-blinkDistance, -blinkDistance, 0);
        }

        transform.position += blink;
    }
    
    
    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", _movement.x);
        animator.SetFloat("Vertical", _movement.y);
        animator.SetFloat("Speed", _movement.sqrMagnitude);

        // Add blink animator.
        if (Input.GetKeyDown(KeyCode.Space) && canBlink)
        {
            animator.SetBool("Blink", true);
            canBlink = false;
        }
        else
        {
            animator.SetBool("Blink", false);
        }
        if (!canBlink)
        {
            _blinkTimer += Time.deltaTime;
        }
        if (_blinkTimer > blinkTime)
        {
            canBlink = true;
            _blinkTimer = 0;
        }
        if (_movement.x >= 1)
        {
            _facingRight = true;
        }
        else
        {
            _facingRight = false;
        }
        if (_movement.y >= 1)
        {
            _facingUp = true;
        }
        else
        {
            _facingUp = false;
        }
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + _movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
