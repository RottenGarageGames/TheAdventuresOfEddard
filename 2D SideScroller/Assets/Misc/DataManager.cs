using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static GlobalInputManager;

namespace Misc
{
    public static class DataManager
    {
        public static Dictionary<InputAction, InputButton> Bindings { get; set; } = null;

        public static void Save()
        {
            var fileName = DateTime.Now.ToString().Replace('\\', '.').Replace(' ', '_') + ".json";

            var filePath = $"{Application.persistentDataPath}\\Save Files\\{fileName}";

            var saveFile = File.Create(filePath);

            var json = JsonConvert.SerializeObject(Bindings);

            File.WriteAllText(filePath, json);
        }
    }
}