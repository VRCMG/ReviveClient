using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MinunnClient.Menu
{
    public class MClientVRButton
    {
        public string Menu { get; set; }

        public string ID { get; set; }

        public string Name { get; set; }

        public string Tooltip { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public MClientColorScheme ColorScheme { get; set; }

        public bool AllowReposition { get; set; }

        public MClientVRButton(string id, string menu, string name, string tooltip, int x, int y, MClientColorScheme scheme, bool allowreposition)
        {
            ID = id;
            Menu = menu;
            Name = name;
            Tooltip = tooltip;
            X = x;
            Y = y;
            ColorScheme = scheme;
            AllowReposition = allowreposition;
        }
    }
}