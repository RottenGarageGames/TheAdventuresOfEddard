using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D RigidBody;
    public int Speed;
    public int JumpForce;
    public int GravityPull;
    public Transform GroundCheck;
    public LayerMask ground;
    public float checkRadius;

    private Vector2 _gravity;

    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        _gravity = new Vector2(0, -1100 * Time.fixedDeltaTime * GravityPull);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var jump = Input.GetAxisRaw("Jump");

        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, ground);

        RigidBody.AddForce(_gravity);

        RigidBody.velocity = new Vector2(horizontal * 100 * Time.fixedDeltaTime * Speed, RigidBody.velocity.y);

        if (jump > 0 && _isGrounded)
        {
            RigidBody.AddRelativeForce(new Vector2(0, 39000 * Time.fixedDeltaTime * JumpForce * jump));
        }

        //if(horizontal != 0)
        //{
        //    var xAngle = horizontal > 0 ? 180 : 0;

        //    gameObject.transform.Rotate(0, 0, xAngle);
        //}
    }
}
