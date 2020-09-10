using MinunnClient.Menu;
using MinunnClient.Menu.Buttons;
using MinunnClient.Settings;
using MinunnClient.Wrappers;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MinunnClient.Utils
{
    public class VRUtilsMenu : QMNestedButton
    {
        public VRUtilsMenu(QMNestedButton parent, MClientVRButton config) : base(parent, config.X, config.Y, config.Name, config.Tooltip, GeneralUtils.GetColor(config.ColorScheme.Colors[0]), GeneralUtils.GetColor(config.ColorScheme.Colors[1]), GeneralUtils.GetColor(config.ColorScheme.Colors[2]), GeneralUtils.GetColor(config.ColorScheme.Colors[3]))
        {
            new AudioVRMenu(this);
            new ProgramVRMenu(this);
        }
    }
}
