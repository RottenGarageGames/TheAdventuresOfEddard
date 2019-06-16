using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityInterfaces
{
    public interface IStackable
    {

        void DecreaseCount(int amount);
        void IncreaseCount(int amount);
    }
}