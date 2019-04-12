using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class ChainGun : BaseItem
    {
        public override void Action()
        {
            coll.GetComponent<Player>().ChainGun = true;
        }
    }

}
