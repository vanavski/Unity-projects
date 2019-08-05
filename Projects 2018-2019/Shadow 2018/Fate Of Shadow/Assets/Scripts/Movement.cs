using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    public float jumpForce;
    public LayerMask whatIsGround;

    private bool IsGrounded;
    public Transform feetPos;
    public float checkRadius;

    private float JumpTimeCounter;
    public float JumpTime;
    private bool IsJumping = true;


    //////сделать пул объектов для оптимизации игры
    //////включение объектов, если они в радиусе действия и их выключение если не в радиусе

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
       GetMotion();
    }

    void Update()
    {
       GetJump();
    }

    public void GetMotion()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void GetJump()
    {
        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            IsJumping = true;
            JumpTimeCounter = JumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && IsJumping == true)
        {
            if (JumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                JumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                IsJumping = false;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;
        }
    }
}
