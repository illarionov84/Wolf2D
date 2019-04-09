using UnityEngine;
using System.Collections;

namespace Wolf2D
{

    public class ObjectiveTrigger : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Managers.Mission.ReachObjective();
            }
        }
    }

}
