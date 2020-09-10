using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MinunnClient.MClientInput
{
    public class MClientKeybind
    {
        public MClientFeature Target { get; set; }

        public KeyCode FirstKey { get; set; }

        public KeyCode SecondKey { get; set; }

        public bool MultipleKeys = false;

        public MClientKeybind(MClientFeature feature, KeyCode first, KeyCode second, bool multiple)
        {
            Target = feature;
            FirstKey = first;
            SecondKey = second;
            MultipleKeys = multiple;
        }
    }
}
