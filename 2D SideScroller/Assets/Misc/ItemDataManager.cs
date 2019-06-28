using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Misc
{
    public static class ItemDataManager
    {
        public static List<ItemData> ItemDataCache
        {
            get
            {
                if (_itemDataCache is null)
                {
                    _itemDataCache = new List<ItemData>();

                    var objects = Resources.LoadAll("Items").Where(x => x.GetType() == typeof(ItemData)).ToList();

                    foreach(var obj in objects)
                    {
                        _itemDataCache.Add(obj as ItemData);
                    }
                }

                return _itemDataCache;
            }
        }
        public static List<ItemData> _itemDataCache;
    }
}
