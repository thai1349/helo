using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private Rigidbody2D _rigidbody2D;
    Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
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

    void OnJump()
    {
        Debug.Log(">>>>> Jump");
    }

    // dieu khien chuyen dong nhan vat
    void Run()
    {
        var moveVelocity = new Vector2(x: moveInput.x * moveSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = moveVelocity;
    }
}
