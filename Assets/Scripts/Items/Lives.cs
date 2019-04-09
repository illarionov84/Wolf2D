using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class Lives : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.GetComponent<Player>().Lives++;
                collision.GetComponent<Player>().Health = 100;
                collision.GetComponent<Player>().Ammo = 99;
                Destroy(gameObject);
            }
        }
    }

}
