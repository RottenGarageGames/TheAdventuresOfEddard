using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : Attack
{
    
    Rigidbody2D projectileRB;

    public int numberOfProjectiles;
    public float projectileSpeed;
    public float areaDamagePerSec;
    Vector3 targetPosition;
    //Selections for Easy Monster Creation

    [Tooltip("Follows the player until destroyed.")]
    public bool isHoming;
    [Tooltip("Shoots at current player position and continues until destroyed")]
    public bool isBullet;
    [Tooltip("Shoots at current player position and stops there")]
    public bool shootAndStopAtPlayerPos;
    [Tooltip("Shoots and stops after a certain time based on ShootAndStopTime")]
    public bool isShootAndStop;
    public bool hasAreaEffectDamage;

    public float ShootAndStopTime;
    public float ShootStopTimer;
    private Vector2 _trajectory;
    public float DestroyAfterSeconds;
    public bool hasDestroyAttackAfterTime;



    // Start is called before the first frame update
    void Start()
    {
        var projectileTransform = gameObject.transform;
        Debug.Log(_trajectory);
       
        projectileRB = gameObject.GetComponent<Rigidbody2D>();
        targetPosition = target.transform.position;
        Debug.Log(targetPosition);
        projectileRB.velocity = (targetPosition - projectileRB.transform.position).normalized * projectileSpeed;
        _trajectory = (targetPosition - projectileRB.transform.position).normalized * projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHoming)
        {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, projectileSpeed);
            
        }
        else if(isBullet)
        {
            
            projectileRB.velocity = _trajectory;

        }
        else if(shootAndStopAtPlayerPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, projectileSpeed);
        }
        else if(isShootAndStop)
        {

            ShootStopTimer += Time.deltaTime;

            if (ShootStopTimer < ShootAndStopTime)
            {
                projectileRB.velocity = _trajectory;
            }
            else
            {
                projectileRB.velocity = Vector2.zero;
            }
        }
        DestroyObject();
    }
    public void DestroyObject()
    {
        if (hasDestroyAttackAfterTime)
        {
            Destroy(gameObject, DestroyAfterSeconds);
        }
    }
}
