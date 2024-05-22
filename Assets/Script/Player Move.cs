using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 10f;
    private Rigidbody2D _rigidbody2D;
    Vector2 moveInput;
    private Animator _anmator;
    CapsuleCollider2D _capsuleCollider2D; 
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _anmator = GetComponent<Animator>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {

        Run();
        FlipSprite();
    }

    void OnMove(InputValue Value)
    {
        moveInput = Value.Get<Vector2>();
        Debug.Log(message: ">>>>> Move Input: " + moveInput); 
        // move input
        // (1,0) Right
        // (-1,0) Left
        // (0,1) Up
        // (0,-1) Down
    }

    void OnJump(InputValue value) 
    {
        var isTouchingGroud = _capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (!isTouchingGroud) return;
        if(value.isPressed)
        {
            Debug.Log(message: ">>>>> Jump");
            _rigidbody2D.velocity += new Vector2(x: 0, y: jumpSpeed);
        }
    }

    // dieu khien chuyen dong nhan vat
    void Run()
    {
        var moveVelocity = new Vector2(x:moveInput.x * moveSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = moveVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(moveInput.x) > Mathf.Epsilon;
        _anmator.SetBool(name:"isRuning", playerHasHorizontalSpeed);
    }

    // Abs: gia tri tuyet doi 
    // Sign: dau cua gia tri
    // Epsilon: gia tri nho nhat co the so sanh 
    // xoay huong nhan vat theo chieu chuyen dong 
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(x:Mathf.Sign(_rigidbody2D.velocity.x), y:1f);
        }
    }
}
