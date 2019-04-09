using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class BaseObject : MonoBehaviour
    {
        public static List<BaseObject> allTicks = new List<BaseObject>();
        public static List<BaseObject> allFixedTicks = new List<BaseObject>();
        public static List<BaseObject> allLateTicks = new List<BaseObject>();

        private void OnEnable()
        {
            allTicks.Add(this);
            allFixedTicks.Add(this);
            allLateTicks.Add(this);
        }

        private void OnDisable()
        {
            allTicks.Remove(this);
            allFixedTicks.Remove(this);
            allLateTicks.Remove(this);
        }

        public void Tick()
        {
            OnTick();
        }

        public void FixedTick()
        {
            OnFixedTick();
        }

        public void LateTick()
        {
            OnLateTick();
        }

        public virtual void OnTick()
        {

        }

        public virtual void OnFixedTick()
        {

        }

        public virtual void OnLateTick()
        {

        }

    }

}
