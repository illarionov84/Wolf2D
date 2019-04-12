using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class DebugGUI : BaseObject
    {
        private float fps;

        private void OnGUI()
        {
            GUI.Box(new Rect(10, 10, 120, 25), "FPS = " + fps);
        }

        public override void OnTick()
        {
            fps = 1 / Time.deltaTime;
        }
    }
}
