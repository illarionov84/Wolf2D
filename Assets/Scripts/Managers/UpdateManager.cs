using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class UpdateManager : MonoBehaviour
    {
        void Update()
        {
            for (int i = 0; i < BaseObject.allTicks.Count; i++)
            {
                BaseObject.allTicks[i].Tick();
            }
        }

        void FixedUpdate()
        {
            for (int i = 0; i < BaseObject.allFixedTicks.Count; i++)
            {
                BaseObject.allFixedTicks[i].Tick();
            }
        }

        void LateUpdate()
        {
            for (int i = 0; i < BaseObject.allLateTicks.Count; i++)
            {
                BaseObject.allLateTicks[i].Tick();
            }
        }
    }

}
