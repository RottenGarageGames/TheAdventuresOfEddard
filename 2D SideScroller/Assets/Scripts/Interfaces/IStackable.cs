using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityInterfaces
{
    public interface IStackable
    {
        int StackSize { get; set; }
        int MaxStackSize { get; set; }

        void DecreaseCount(int amount);
        void IncreaseCount(int amount);
    }
}