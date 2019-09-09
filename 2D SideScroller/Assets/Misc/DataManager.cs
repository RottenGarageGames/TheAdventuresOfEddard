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
        public static Dictionary<InputAction, InputButton> ControllerBindings { get; set; } = null;
        public static Dictionary<InputAction, KeyCode> KeyboardBindings { get; set; } = null;
        public static BankData PlayerOneBankData { get; set; } = null;
        public static BankData PlayerTwoBankData { get; set; } = null;
        public static BankData PlayerThreeBankData { get; set; } = null;
        public static BankData PlayerFourBankData { get; set; } = null;


        public static void Load()
        {
            var directory = new DirectoryInfo(Application.persistentDataPath);
            var lastSave = directory.GetFiles().OrderByDescending(x => x.LastWriteTime).FirstOrDefault();

            //Last save is being loaded if you do a build of the game on your computer
            //I'm setting it to null to test. Shouldn't be an issue when there are actual save files to load.
            lastSave = null;
            if (lastSave != null)
            {
                var json = File.ReadAllText(lastSave.FullName);

                var data = JsonConvert.DeserializeObject<GameData>(json);

                ControllerBindings = data.ControllerBindings;
                KeyboardBindings = data.KeyboardBindings;
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
                JsonConvert.SerializeObject(KeyboardBindings),
                JsonConvert.SerializeObject(ControllerBindings),
                JsonConvert.SerializeObject(PlayerOneBankData),
                JsonConvert.SerializeObject(PlayerTwoBankData),
                JsonConvert.SerializeObject(PlayerThreeBankData),
                JsonConvert.SerializeObject(PlayerFourBankData)
            };

            File.WriteAllLines(filePath, data);
        }

        private static void LoadDefaults()
        {
            ControllerBindings = new Dictionary<InputAction, InputButton>();

            ControllerBindings.Add(InputAction.Jump, InputButton.RightThumbButton);
            ControllerBindings.Add(InputAction.Interact, InputButton.LeftThumbButton);
            ControllerBindings.Add(InputAction.InventoryWheel, InputButton.BottomThumbButton);
            ControllerBindings.Add(InputAction.Run, InputButton.TopThumbButton);
            ControllerBindings.Add(InputAction.Ability1, InputButton.LeftBumper);
            ControllerBindings.Add(InputAction.Attack1, InputButton.LeftTrigger);
            ControllerBindings.Add(InputAction.Ability2, InputButton.RightBumper);
            ControllerBindings.Add(InputAction.Attack2, InputButton.RightTrigger);

            KeyboardBindings = new Dictionary<InputAction, KeyCode>();

            KeyboardBindings.Add(InputAction.Jump, KeyCode.Space);
            KeyboardBindings.Add(InputAction.Interact, KeyCode.E);
            KeyboardBindings.Add(InputAction.InventoryWheel, KeyCode.I);
            KeyboardBindings.Add(InputAction.Run, KeyCode.F);
            KeyboardBindings.Add(InputAction.Ability1, KeyCode.R);
            KeyboardBindings.Add(InputAction.Attack1, KeyCode.Mouse0);
            KeyboardBindings.Add(InputAction.Ability2, KeyCode.Q);
            KeyboardBindings.Add(InputAction.Attack2, KeyCode.Mouse1);
            KeyboardBindings.Add(InputAction.Left, KeyCode.A);
            KeyboardBindings.Add(InputAction.Right, KeyCode.D);
            KeyboardBindings.Add(InputAction.Crouch, KeyCode.S);
        }
    }
}

public class GameData
{
    public Dictionary<InputAction, InputButton> ControllerBindings { get; private set; } = null;
    public Dictionary<InputAction, KeyCode> KeyboardBindings { get; private set; } = null;

    public GameData(Dictionary<InputAction, InputButton> controllerBindings, Dictionary<InputAction, KeyCode> keyboardBindings)
    {
        ControllerBindings = controllerBindings;
        KeyboardBindings = keyboardBindings;
    }
}