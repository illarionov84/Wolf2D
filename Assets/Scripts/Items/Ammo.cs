using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class Ammo : BaseItem
    {
        public override void Action()
        {
            isDestroy = false;
            if (coll.GetComponent<Player>().Ammo < 99)
            {
                coll.GetComponent<Player>().Ammo += 8;
                isDestroy = true;
            }
        }
    }

}
