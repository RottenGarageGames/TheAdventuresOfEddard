using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Old script. saving for reference but need to delete
public class oldAttack : MonoBehaviour
{
    public float damage;
    public float coolDownTime;
    public string attackName;
    public string attackType;
    public KeyCode keyCode;
    private float _timer;
    public CircleCollider2D areaOfEffect;
    public GameObject target;



    //cooldown time has been reached
    public bool readyForUse;


    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= coolDownTime)
        {
            readyForUse = true;
        }
        else
        {
            readyForUse = false;
        }
    }
    public float GetDamage()
    {
        return damage;
    }
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
    public void RemoveTarget(GameObject targetToRemove)
    {
        if (targetToRemove.tag == target.tag)
        {
            target = null;
        }
    }

}
