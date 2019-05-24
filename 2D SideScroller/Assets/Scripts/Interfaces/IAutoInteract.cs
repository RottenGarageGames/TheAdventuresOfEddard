using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public interface IAutoInteract
{
        float interactRadius { get; set; }
        void Interact(GameObject gameObject);
}
