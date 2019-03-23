using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityInterfaces
{
        // Start is called before the first frame update
        public interface IInventoryItem
        {
            String name { get; set; }
            int itemID { get; set; }
        }
        
        

}
