﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool _facingRight;
    private bool _isOnGround;
    [SerializeField] float jumpForce = 6f;
    [SerializeField] float moveSpeed = 2f;
    public Rigidbody2D acornProjectile;
    public int health = 3;

    public int numberOfAcorns = 0;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _facingRight = true;
        _isOnGround = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        //Right
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            var velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), _rigidbody.velocity.y);
            _rigidbody.velocity = velocity;
            if (!_facingRight)
            {
                FlipDirection();
            }
        }

        //Left
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            var velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), _rigidbody.velocity.y);
            _rigidbody.velocity = velocity;
            if (_facingRight)
            {
                FlipDirection();
            }
        }

        if (Input.GetButtonDown("Jump") && _isOnGround)
        {
            _isOnGround = false;
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            _isOnGround = true;
        }
    }

    private void FlipDirection()
    {
        _facingRight = !_facingRight;
        var existingScale = _rigidbody.transform.localScale;
        var newScale = new Vector3(-existingScale.x, existingScale.y, existingScale.z);
        _rigidbody.transform.localScale = newScale;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Acorn"))
        {
            numberOfAcorns++;
        }
    }
}
