using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityInterfaces
{
    public interface IRarity
    {
        string rarity { get; set; }
        List<string> rarityOptions { get; set; }

        void DetermineRarity();
    }
}
