using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUp : MonoBehaviour
{
    public float MovementSpeed;
    public float TransitionTime;
    public Rigidbody2D _platformRigidbody;
    public float _time;
    public bool _isMovingUp;


    // Start is called before the first frame update
    void Start()
    {
        _platformRigidbody = gameObject.GetComponent<Rigidbody2D>();
        _isMovingUp = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _time += Time.deltaTime;

        if (_time >= TransitionTime)
        {
            _time = 0;
            _isMovingUp = !_isMovingUp;
            _platformRigidbody.velocity = Vector2.zero;

        }

        if (_isMovingUp)
        {
            _platformRigidbody.AddForce(Vector2.up * MovementSpeed);
        }
        else
        {
            _platformRigidbody.AddForce(Vector2.down * MovementSpeed);
        }





    }
}

