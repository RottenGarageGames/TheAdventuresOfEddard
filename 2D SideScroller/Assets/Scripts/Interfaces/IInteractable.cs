using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityInterfaces
{
    public interface IInteractable
    {
        float interactRadius { get; set; }
        void Interact();
    }
}
