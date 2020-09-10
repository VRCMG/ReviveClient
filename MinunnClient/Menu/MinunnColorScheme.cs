using MinunnClient.Settings;
using MinunnClient.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MinunnClient.Menu
{
    public class MClientColorScheme
    {
        public List<MClientColor> Colors = new List<MClientColor>();

        public MClientColorScheme(Color btnBackgroundColor, Color btnTextColor, Color backbtnBackgroundColor, Color backbtnTextColor)
        {
            Colors.Add(GeneralUtils.GetMClientColor(btnBackgroundColor));
            Colors.Add(GeneralUtils.GetMClientColor(btnTextColor));
            Colors.Add(GeneralUtils.GetMClientColor(backbtnBackgroundColor));
            Colors.Add(GeneralUtils.GetMClientColor(backbtnTextColor));
        }
        //more stuff to be added ok
    }
}