using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

public class Player : MonoBehaviour
{
    Animator _playerAnimator;
    Rigidbody2D _playerRb;
    BoxCollider2D _playerCollider;
    Vector2 mov;

    //internas
    [SerializeField]
    float playerSpeed = 4;
    [SerializeField]
    float playerJump = 20;

    bool canDoubleJump;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
    }


    void Movimentacao()
    {
        _playerRb.velocity = new Vector2(mov.x * playerSpeed, _playerRb.velocity.y);

        bool isRunning = Mathf.Abs(_playerRb.velocity.x) > Mathf.Epsilon;

        if (isRunning)
            FlipSprite();

    }

    void FlipSprite()
    {
        transform.localScale = new Vector3(Mathf.Sign(_playerRb.velocity.x), 1, 1);
    }

    void OnMove(InputValue inputValue)
    {
        mov = inputValue.Get<Vector2>();
    }

    void OnJump(InputValue inputValue)
    {

        if (inputValue.isPressed)
        {
            if (_playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                _playerRb.velocity = new Vector2(_playerRb.velocity.x * 1.1f, playerJump);
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                _playerRb.velocity = new Vector2(_playerRb.velocity.x * 1.1f, playerJump);
                canDoubleJump = false;
            }
        }

    }
}
