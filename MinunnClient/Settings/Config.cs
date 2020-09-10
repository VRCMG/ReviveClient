using MinunnClient.API;
using MinunnClient.MClientInput;
using MinunnClient.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace MinunnClient.Settings
{
    public class Config
    {
        public bool
            CleanConsole = true,
            Optimization = false,
            LogModerations = false,
            AntiPublicBan = true,
            AntiKick = true,
            AntiPhotonBot = true,
            NoUSpeakExploits = true,
            VideoPlayerSafety = true,
            AntiBlock = true,
            PortalSafety = true,
            AntiWorldTriggers = true,
            UseRichPresence = true,
            MenuRGB = false,
            coolemoji = false,
            coolemoji2 = false,
            DefaultLogToConsole = true;

        public string ClientVersion = "1.0";

        public List<FavoritedAvatar> ExtendedFavoritedAvatars = new List<FavoritedAvatar>();

        public List<MClientVRButton> Buttons = new List<MClientVRButton>();

        public List<MClientKeybind> Keybinds = new List<MClientKeybind>();
    }
}
