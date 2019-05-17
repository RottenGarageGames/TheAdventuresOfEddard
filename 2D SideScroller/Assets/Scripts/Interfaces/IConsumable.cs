using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityInterfaces
{
    public interface IConsumable
    {
        void Consume(GameObject playerAttachedToInventory);
    }
}
