using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public KeyCode upButton;
    public KeyCode DownButton;
    private Rigidbody2D myRB;
    public int yDirection;
    public bool moving;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        myRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            myRB.velocity = new Vector2(myRB.velocity.x, speed * Time.deltaTime * yDirection);
        }
    }

   void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player" && Input.GetKeyDown(upButton))
        {
            Debug.Log("hot air balloon should be moving");
            yDirection = 1;
            moving = true;
            myRB.gravityScale = 0;
        }
        if (collider.gameObject.tag == "Player" && Input.GetKeyDown(DownButton))
        {
            Debug.Log("hot air balloon should be moving");
            yDirection = -1;
            moving = true;
            myRB.gravityScale = 0;
        }
        else
        {

        }
        
    }
}
