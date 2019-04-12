using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class Lives : BaseItem
    {
        public override void Action()
        {
            coll.GetComponent<Player>().Lives++;
            coll.GetComponent<Player>().Health = 100;
            coll.GetComponent<Player>().Ammo = 99;
        }
    }

}
