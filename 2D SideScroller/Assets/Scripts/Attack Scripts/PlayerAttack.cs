using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPoint;
    public float timeBetweenShots;
    public float shotTimer;
    public float attackDuration;
    public KeyCode keyCode;
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        // Set the ability to be cooled down
        shotTimer = timeBetweenShots;
        Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer += Time.deltaTime;

        if (Input.GetKey(keyCode) && shotTimer > timeBetweenShots)
        {
            Animator.SetBool("isAttacking", true);
           var newProjectile = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
            
            if (transform.localScale.x < 0)
            {
                newProjectile.SendMessage("FacingRight");

            }
            else
            {
                newProjectile.SendMessage("NotFacingRight");
            }
            shotTimer = 0; 
        }
    }
}
