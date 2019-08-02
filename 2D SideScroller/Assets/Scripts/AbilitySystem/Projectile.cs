using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Sprite Sprite;
    public int Damage { get; set; }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<IDamagable>()?.TakeDamage(Damage);
        //Add Animation Logic
        Destroy(gameObject);
    }
}
