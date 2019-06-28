using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class CalebPlayerController : MonoBehaviour
{
    public enum PlayerDirection { Left, Right };
    public enum PlayerID {PlayerOne, PlayerTwo, PlayerThree, PlayerFour };

    public Rigidbody2D RigidBody { get; private set; }

    public float WalkSpeed = 10;
    public float RunSpeed = 16;
    public float JumpForce = 10;

    public PlayerDirection Direction { get; private set; }

    public PlayerStats PlayerStats = new PlayerStats();
    public PlayerWheel playerWheel;

    public PlayerGUIScript PlayerHealthScript;

    public bool Running;
    public bool IsGrounded { get; private set; }
    public Transform GroundCheck;
    public LayerMask Ground;
    public float PlayerCurrentFlipValue;
    public PlayerID ID;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        PlayerCurrentFlipValue = transform.rotation.y;
    }
    
    void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.3f, Ground);

        //if(Input.GetKeyDown(KeyCode.L))
        //{
        //    Damage();
        //}
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

    public void Jump()
    {
        if (IsGrounded)
        {
            var y = JumpForce * 4;

            RigidBody.velocity = new Vector2(RigidBody.velocity.x, y);
        }
    }

    public void Interact()
    {

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

    public void Damage(int damage = 1)
    {
        PlayerHealthScript.Damage(PlayerStats.Health);

        PlayerStats.Health -= damage;

        if(PlayerStats.Health <= 0)
        {
            GameManager.KillPlayer(this);
        }
    }

    public void ShowWheel()
    {
        playerWheel.Show();
    }
}
