using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityInterfaces
{
    public interface IStackable
    {
        int stackSize { get; set; }
        int maxStackSize { get; set; }
    }
}