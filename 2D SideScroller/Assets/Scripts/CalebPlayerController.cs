using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CalebPlayerController : MonoBehaviour
{
    public enum PlayerDirection { Left, Right };

    public Rigidbody2D RigidBody { get; private set; }

    public float WalkSpeed = 10;
    public float RunSpeed = 18;
    public float JumpForce = 10;

    public PlayerDirection Direction { get; private set; }
    
    public bool Running { get; set; }
    public bool IsGrounded { get; private set; }
    public Transform GroundCheck;
    public LayerMask Ground;
    public float PlayerCurrentFlipValue;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        PlayerCurrentFlipValue = transform.rotation.y;
    }
    
    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.3f, Ground);
    }

    public void HorizontalMove(float horizontalInput)
    {
        if (horizontalInput != 0)
        {
            UpdateDirection(horizontalInput > 0 ? PlayerDirection.Right : PlayerDirection.Left);
        }

        var speed = Running ? RunSpeed : WalkSpeed;

        var x = horizontalInput * 2 * speed;

        RigidBody.velocity = new Vector2(x, RigidBody.velocity.y);
    }

    public void Jump(float input)
    {
        if (IsGrounded)
        {
            var y = input * JumpForce * 4;

            RigidBody.velocity = new Vector2(RigidBody.velocity.x, y);
        }
    }

    private void UpdateDirection(PlayerDirection playerDirection)
    {
        if (Direction == playerDirection)
        {
            return;
        }

        Direction = playerDirection;

        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
