using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGUI : MonoBehaviour
{
    private float fps;

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 120, 25), "FPS = " + fps);
    }

    private void Update()
    {
        fps = 1 / Time.deltaTime;
    }
}
