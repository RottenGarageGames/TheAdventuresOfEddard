using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static GlobalInputManager;

namespace Misc
{
    public static class DataManager
    {
        public static Dictionary<InputAction, InputButton> Bindings { get; set; } = null;

        public static void Load()
        {
            var directory = new DirectoryInfo(Application.persistentDataPath);
            var lastSave = directory.GetFiles().OrderByDescending(x => x.LastWriteTime).FirstOrDefault();

            if (lastSave is null)
            {
                var json = File.ReadAllText(lastSave.FullName);

                var data = JsonConvert.DeserializeObject<GameData>(json);

                Bindings = data.Bindings;
            }
            else
            {
                LoadDefaults();
            }
        }

        public static void Save()
        {
            var fileName = DateTime.Now.ToString().Replace('/', '.').Replace(' ', '_').Replace(':', '.') + ".json";

            var filePath = $"{Application.persistentDataPath.Replace('/', '\\')}\\{fileName}";

            string[] data =
            {
                JsonConvert.SerializeObject(Bindings)
            };

            File.WriteAllLines(filePath, data);
        }

        private static void LoadDefaults()
        {
            Bindings = new Dictionary<InputAction, InputButton>();

            Bindings.Add(InputAction.Jump, InputButton.BottomThumbButton);
            Bindings.Add(InputAction.Interact, InputButton.LeftThumbButton);
            Bindings.Add(InputAction.InventoryWheel, InputButton.RightThumbButton);
            Bindings.Add(InputAction.Run, InputButton.TopThumbButton);
            Bindings.Add(InputAction.Ability1, InputButton.LeftBumper);
            Bindings.Add(InputAction.Attack1, InputButton.LeftTrigger);
            Bindings.Add(InputAction.Ability2, InputButton.RightBumper);
            Bindings.Add(InputAction.Attack2, InputButton.RightTrigger);
        }
    }
}

public class GameData
{
    public Dictionary<InputAction, InputButton> Bindings { get; private set; }

    public GameData(Dictionary<InputAction, InputButton> bindings)
    {
        Bindings = bindings;
    }
}