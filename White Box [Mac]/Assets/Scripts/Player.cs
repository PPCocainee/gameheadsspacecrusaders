using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.5f;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private float groundDist = 100f;

    public bool isRobot;
    public bool Grounded;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private float moveInput;
    //private Controls controls;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Move();
        Jump();
        Grounded = Physics2D.Raycast(transform.position, groundCheck.position, LayerMask.GetMask("Ground"));
    }


    private void Move()
    {
        if ((!isRobot && !GameManager.instance.controllingRobot) || (isRobot && GameManager.instance.controllingRobot))
        {
            moveInput = UserInput.instance.moveInput.x;

            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
    }

    private void Jump()
    {
        if (Grounded && UserInput.instance.controls.Movement.Jump.triggered)
        {
            if ((!isRobot && !GameManager.instance.controllingRobot) || (isRobot && GameManager.instance.controllingRobot))
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                print("Should be jumping");
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundDist);
    }

}
