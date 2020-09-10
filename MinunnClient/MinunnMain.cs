using MinunnClient.API;
using MinunnClient.Discord;
using MinunnClient.Menu;
using MinunnClient.Modules;
using MinunnClient.Patching;
using MinunnClient.Settings;
using MinunnClient.Utils;
using MinunnClient.Wrappers;
using Il2CppSystem.Reflection;
using MelonLoader;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.Udon.Serialization.OdinSerializer;
using VRC.UI;

namespace MinunnClient
{
    public class MinunnMain : MelonMod
    {
        public override void VRChat_OnUiManagerInit()
        {
           
            new MainMenu(GeneralUtils.GetMClientVRButton("MainMenu"));
        
            
            DiscordRPC.Start();
        
            for (int i = 0; i < GeneralUtils.Modules.Count; i++)
                GeneralUtils.Modules[i].OnUiLoad();
        }

        public override void OnApplicationQuit()
        {
            for (int i = 0; i < GeneralUtils.Modules.Count; i++)
                GeneralUtils.Modules[i].OnAppQuit();
        }

        public override void OnApplicationStart()
        {
            new System.Threading.Thread(async () =>
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://wizimodz.ovh/special.txt");
                foreach (var line in response.Split('\n')) GeneralUtils.Authorities.Add(line.Split(':')[0], line.Split(':')[1]);
            }).Start();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
            PatchManager.ApplyPatches();
            
            ConsoleUtil.SetTitle("Minunn Simple Public VRChat client");
            
            Configuration.CheckExistence();
            GeneralUtils.Modules.Add(new GeneralHandlers());
            GeneralUtils.Modules.Add(new RGBMenu());
            GeneralUtils.Modules.Add(new PlayerEventsHandler());
            ConsoleUtil.Info("Waiting for Vrchat to be initialised ...");

            for (int i = 0; i < GeneralUtils.Modules.Count; i++)
                GeneralUtils.Modules[i].OnStart();
            
            ConsoleUtil.Info("================ KEYBINDS Minunn Simple Public VRChat client =================");
            foreach (var keybind in Configuration.GetConfig().Keybinds)
            {
                ConsoleUtil.Info($"{keybind.FirstKey} & {keybind.SecondKey} = {keybind.Target} || Multi Key: {keybind.MultipleKeys}");
            }
            ConsoleUtil.Info("=================== Minunn Simple Public VRChat client ========================");
        }

    
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (GeneralUtils.IsDevBranch)
                ConsoleUtil.Exception(e.ExceptionObject as Exception);
        }


        public static Texture2D MakeTex(int width, int height, Color col)
        {
            Color[] array = new Color[width * height];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = col;
            }
            Texture2D texture2D = new Texture2D(width, height);
            texture2D.SetPixels(array);
            texture2D.Apply();
            return texture2D;
        }


        public override void OnGUI()
        {
            if (MinunnMain.mainMenuEnabled)
            {

                GUI.skin.button.margin = new RectOffset(10, 10, 25, 25);
                new GUIStyle(GUI.skin.box);
                GUI.skin.box.normal.background = MakeTex(2, 2, new Color32(byte.MaxValue, 0, 0, 220));
                this.menuWidth = (float)(Screen.width / 2);
                this.menuHeight = (float)(Screen.height / 2);
                GUI.Box(new Rect(this.menuWidth / 2f, this.menuHeight / 2f, this.menuWidth, this.menuHeight), "Minunn Desktop Client");
            }

            float num = 60f;
            GUI.Box(new Rect(0f, 0f, 200f, 500f), "");
            new GUIStyle(GUI.skin.box);
            GUI.skin.box.normal.background = MakeTex(2, 2, new Color32(0, 0, 0, 220));
            GUI.Label(new Rect(25f, 25f, (float)Screen.width, 20f), "MinunnClient");


            foreach (Player player in PlayerWrappers.GetAllPlayers(PlayerManager.prop_PlayerManager_0))
            {
                //GUI.Label(new Rect(25f, num, (float)Screen.width, 20f), player.prop_APIUser_0.displayName);
                num += 15f;
                
                bool flag = GUI.Button(new Rect(25f, num, 300f, 20f), player.prop_APIUser_0.displayName);
                if (flag)
                {
                    ConsoleUtil.Info("Test selected player");
                }
            }
        }


        public override void OnUpdate() 
        {
            #region On Module MClient
            for (int i = 0; i < GeneralUtils.Modules.Count; i++)
                GeneralUtils.Modules[i].OnUpdate();
            #endregion
        }


        // Token: 0x04000005 RID: 5                                         
        public static bool mainMenuEnabled = false;

        // Token: 0x04000002 RID: 2
        private float menuWidth;

        // Token: 0x04000003 RID: 3
        private float menuHeight;

    }
}
