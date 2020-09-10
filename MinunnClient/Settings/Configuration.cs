using MinunnClient.MClientInput;
using MinunnClient.Menu;
using MinunnClient.Utils;
using Newtonsoft.Json;
using System.ComponentModel.Design;
using System.IO;
using UnityEngine;

namespace MinunnClient.Settings
{
    public static class Configuration
    {
        public const string ConfigLocation = "MinunnClient\\Config.json";

        private static Config _Config { get; set; }

        public static void SaveConfiguration() =>
            File.WriteAllText(ConfigLocation, JsonConvert.SerializeObject(_Config, Formatting.Indented));

        public static void CheckExistence()
        {
            Directory.CreateDirectory("MinunnClient");
            if (!File.Exists(ConfigLocation))
            {
                var config = new Config();
                if (GeneralUtils.IsDevBranch)
                    config.Buttons.Add(new MClientVRButton("MainMenu", "ShortcutMenu", "MinunnClient\nClient", "A client made for my friends", 5, 2, new MClientColorScheme(Color.red, Color.white, Color.red, Color.white), true));
                config.Buttons.Add(new MClientVRButton("ExtendedFavorites", null, "Extended\nFavorites", "Simple fav list", 4, 1, new MClientColorScheme(Color.red, Color.white, Color.red, Color.white), true));
                config.Buttons.Add(new MClientVRButton("Fun", null, "Fun", "A menu full of fun stuff!", 2, 1, new MClientColorScheme(Color.red, Color.white, Color.red, Color.white), true));
                config.Buttons.Add(new MClientVRButton("Protections", null, "Protections", "A menu full of protection options against moderation, and other safety related features.", 3, 1, new MClientColorScheme(Color.red, Color.white, Color.red, Color.white), true));
                config.Buttons.Add(new MClientVRButton("PlayerOptions", "UserInteractMenu", "Player\nOptions", "Open this menu and control what you want of other players.", 1, 2, new MClientColorScheme(Color.red, Color.white, Color.red, Color.white), true));
                config.Buttons.Add(new MClientVRButton("Utils", null, "Utils", "Extended utilities you can use to manage the game better.", 1, 1, new MClientColorScheme(Color.red, Color.white, Color.red, Color.white), true));
                config.Buttons.Add(new MClientVRButton("Settings", null, "Settings", "Configure the client's settings and make it more comfortable for yourself.", 4, 2, new MClientColorScheme(Color.red, Color.white, Color.red, Color.white), true));
                config.Buttons.Add(new MClientVRButton("VRUtils", null, "VR\nUtils", "Allows you to do stuff that would seem harder in VR, but allows you to execute tasks quick and fast.", 3, 2, new MClientColorScheme(Color.red, Color.white, Color.red, Color.white), true));
                config.Keybinds.Add(new MClientKeybind(MClientFeature.Flight, KeyCode.LeftAlt, KeyCode.F, true));
                config.Keybinds.Add(new MClientKeybind(MClientFeature.Autism, KeyCode.LeftAlt, KeyCode.A, true));
                config.Keybinds.Add(new MClientKeybind(MClientFeature.SpinBot, KeyCode.LeftAlt, KeyCode.S, true));
                config.Keybinds.Add(new MClientKeybind(MClientFeature.ESP, KeyCode.LeftAlt, KeyCode.E, true));
                config.Keybinds.Add(new MClientKeybind(MClientFeature.WorldTriggers, KeyCode.LeftAlt, KeyCode.W, true));
                config.Keybinds.Add(new MClientKeybind(MClientFeature.ToggleAllTriggers, KeyCode.LeftAlt, KeyCode.T, true));
                File.WriteAllText(ConfigLocation, JsonConvert.SerializeObject(config, Formatting.Indented));
            }
            LoadConfiguration();
        }

        public static void LoadConfiguration()
        {
            _Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigLocation));
            if (_Config.ClientVersion != GeneralUtils.Version)
                ConsoleUtil.Info("YOU USE OUTDATED VERSION PLEASE DOWNLOAD THE NEW ONE IF YOU DON'T WANT LOSE ACCESS !");
        }

        public static Config GetConfig() => _Config;
    }
}
