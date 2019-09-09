using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D enemyRigid;
    public bool inRange;
    public bool isClosestDistanceToPlayer;
    public float enemyClosestPositionToPlayer;
    public float jumpForce;
    public bool enemyShouldJumpNearPlayer;
    public bool playerAtEdgeOfRadius;
    public GameObject player;
    public float movementSpeed;
    public float timeBetweenJumps;
    private float timer = 0;
    private Animator _animator;
    

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        enemyRigid = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(player.transform.position, gameObject.transform.position) > (gameObject.GetComponent<CircleCollider2D>().radius / 2) - 1)
            {
                playerAtEdgeOfRadius = true;
            }
            else
            {
                playerAtEdgeOfRadius = false;
            }
        }
        //timer += Time.deltaTime;
        //float step = movementSpeed * Time.deltaTime;
        //if (inRange && Vector2.Distance(transform.position, player.transform.position) > enemyClosestPositionToPlayer)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);

        //}
        //if (enemyShouldJumpNearPlayer)
        //{
        //    if (inRange && Vector2.Distance(transform.position, player.transform.position) <= enemyClosestPositionToPlayer)
        //    {
        //        if (timer >= timeBetweenJumps)
        //        {
        //            enemyRigid.velocity = new Vector2(0, jumpForce);
        //            timer = 0;
        //        }
        //    }
        //}
    }
    private void OnTriggerEnter2D(Collider2D newPlayer)
    {
        if (newPlayer.tag == "Player")
        {
            player = newPlayer.gameObject;
            inRange = true;
            isClosestDistanceToPlayer = false;
            this.gameObject.SendMessage("TogglePlayerInRange");
            //this.gameObject.GetComponent<EnemyStats>().collidingWithPlayer = true;
            SendMessage("AttackLoopSetPlayerInRange", newPlayer.gameObject);
            _animator.SetBool("inRange", true);
        }
    }
    private void OnTriggerExit2D(Collider2D newPlayer)
    {
        if (newPlayer.tag == "Player")
        {
            player = null;
            inRange = false;
            this.gameObject.SendMessage("TogglePlayerInRange");
            SendMessage("AttackLoopPlayerOutOfRange", newPlayer.gameObject);
            _animator.SetBool("inRange", false);
            //this.gameObject.GetComponent<EnemyStats>().collidingWithPlayer = false;

        }
    }
}

