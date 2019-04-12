using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class Medkit : BaseItem
    {
        public override void Action()
        {
            isDestroy = false;
            if (coll.GetComponent<Player>().Health < 100)
            {
                coll.GetComponent<Player>().Health += 25;
                isDestroy = true;
            }
        }
    }

}
