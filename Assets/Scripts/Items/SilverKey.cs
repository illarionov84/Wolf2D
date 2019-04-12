using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class SilverKey : BaseItem
    {
        public override void Action()
        {
            coll.GetComponent<Player>().SilverKey = true;
        }
    }

}
