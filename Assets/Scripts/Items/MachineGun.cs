using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class MachineGun : BaseItem
    {
        public override void Action()
        {
            coll.GetComponent<Player>().MachineGun = true;
        }
    }

}
