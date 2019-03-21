using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    protected float moveSpeed = 1f;
    // Start is called before the first frame update
    public void Move(Vector3 movement)
    {
        transform.position += movement * Time.deltaTime * moveSpeed;
    }
}
