using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool _facingRight;
    private bool _isJumping;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _facingRight = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
            var velocity = new Vector2(1f, _rigidbody.velocity.y);
            _rigidbody.velocity = velocity;
            if (!_facingRight)
            {
                FlipDirection();
            }
        }

        //Left
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            var velocity = new Vector2(-1f, _rigidbody.velocity.y);
            _rigidbody.velocity = velocity;
            if (_facingRight)
            {
                FlipDirection();
            }
        }

        if (Input.GetAxis("Jump") > 0)
        {
            _rigidbody.AddForce(new Vector2(0, 0.5f), ForceMode2D.Impulse);
        }
        
    }

    private void FlipDirection()
    {
        _facingRight = !_facingRight;
        var existingScale = _rigidbody.transform.localScale;
        var newScale = new Vector3(-existingScale.x, existingScale.y, existingScale.z);
        _rigidbody.transform.localScale = newScale;
    }
}
