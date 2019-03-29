using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityInterfaces
{
        // Start is called before the first frame update
        public interface IInventoryItem
        {
            String itemName { get; set; }
            int itemID { get; set; }
            Sprite sprite { get; set; }
        }
        
        

}
