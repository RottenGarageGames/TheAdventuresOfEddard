using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterMovement))]
public class AIMovementController : MonoBehaviour
{
    private CharacterMovement _characterMovement;
    // Start is called before the first frame update
    void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        //Moves AI nowhere for now.
        Vector3 direction = Vector3.zero;
        _characterMovement.Move(direction);
    }

    private Vector3 GetDestination()
    {
        //returns nothing for now
        return Vector3.zero;
    }
}
