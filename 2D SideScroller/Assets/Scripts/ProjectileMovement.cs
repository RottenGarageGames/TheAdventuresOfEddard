using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector3 _direction;

    private void Start()
    {
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        _direction = difference;

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 90);
    }
    // Update is called once per frame
    void Update()
    {
        
        Rigidbody2D.velocity = new Vector2(_direction.x * Speed, _direction.y * Speed);
    }
}
