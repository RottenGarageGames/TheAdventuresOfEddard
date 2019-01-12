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
    public bool isHoming;
    public bool isBullet;
    public bool shootAndStopAtPlayerPos;
    public bool isShootAndStop;
    public bool hasAreaEffectDamage;

    public float ShootAndStopTime;
    public float ShootStopTimer;

    private Vector2 _trajectory;



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
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, projectileSpeed * Time.deltaTime);
        }
        else if(isBullet)
        {
            
            projectileRB.velocity = _trajectory;

        }
        else if(shootAndStopAtPlayerPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, projectileSpeed * Time.deltaTime);
        }
        else if(isShootAndStop)
        {

            ShootStopTimer += Time.deltaTime;

            if (ShootStopTimer < ShootAndStopTime)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, projectileSpeed * Time.deltaTime);
            }
            else
            {
                projectileRB.velocity = Vector2.zero;
            }
        }
    }
}
