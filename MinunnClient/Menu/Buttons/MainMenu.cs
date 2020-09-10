using MinunnClient.Settings;
using MinunnClient.Utils;
using MinunnClient.Wrappers;
using Il2CppSystem.Threading;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MinunnClient.Menu
{
    public class MainMenu : QMNestedButton
    {
        public MainMenu(MClientVRButton config) : base(config.Menu, config.X, config.Y, config.Name, config.Tooltip, GeneralUtils.GetColor(config.ColorScheme.Colors[0]), GeneralUtils.GetColor(config.ColorScheme.Colors[1]), GeneralUtils.GetColor(config.ColorScheme.Colors[2]), GeneralUtils.GetColor(config.ColorScheme.Colors[3]))
        {
            new QMSingleButton(this, 2, 0, "Join Discord Vocal", new Action(() =>
            {
                Process.Start("https://discord.gg/HCpcqnb");
            }), "Join the official discord vocal", Color.red, Color.white);
            new QMSingleButton(this, 3, 0, "test", new Action(() =>
            {
                GeneralUtils.InformHudText(Color.yellow, "you gay");
            }), "Displays who made this cheat", Color.red, Color.white);

            new UtilsVRMenu(this, GeneralUtils.GetMClientVRButton("Utils"));
            new FunVRMenu(this, GeneralUtils.GetMClientVRButton("Fun"));
            new ProtectionsVRMenu(this, GeneralUtils.GetMClientVRButton("Protections"));
            new TargetVRMenu(GeneralUtils.GetMClientVRButton("PlayerOptions"));
            new FavoritesVRMenu(this, GeneralUtils.GetMClientVRButton("ExtendedFavorites"));
            new SettingsVRMenu(this, GeneralUtils.GetMClientVRButton("Settings"));
            new VRUtilsMenu(this, GeneralUtils.GetMClientVRButton("VRUtils"));
            new QMSingleButton(this, 4, 0, "Select\nYourself", new Action(() =>
            {
                GeneralWrappers.GetQuickMenu().SelectPlayer(GeneralWrappers.GetPlayerManager().GetCurrentPlayer());
            }), "Select your own current player and do some stuff to yourself, I don't know lol.", Color.red, Color.white);
            new QMToggleButton(this, 1, 2, "Hide\nYourself", new Action(() =>
            {
                GeneralWrappers.GetPlayerManager().GetCurrentPlayer().prop_VRCAvatarManager_0.gameObject.SetActive(false);
            }), "Unhide\nYourself", new Action(() =>
            {
                GeneralWrappers.GetPlayerManager().GetCurrentPlayer().prop_VRCAvatarManager_0.gameObject.SetActive(true);
            }), "Hide/Unhide yourself, for safety reasons maybe, who knows.", Color.red, Color.white);
        }
    }
}
