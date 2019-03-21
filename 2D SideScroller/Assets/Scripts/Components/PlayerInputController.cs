using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class PlayerInputController : MonoBehaviour
{
    private CharacterMovement characterMovement;
    // Start is called before the first frame update
    void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        characterMovement.Move(movement);
    }
}
