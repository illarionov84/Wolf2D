using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class GoldKey : BaseItem
    {
        public override void Action()
        {
            base.coll.GetComponent<Player>().GoldKey = true;
        }
    }

}
