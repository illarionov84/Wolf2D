using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class Ammo : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (collision.GetComponent<Player>().Ammo < 99)
                {
                    collision.GetComponent<Player>().Ammo += 8;
                    Destroy(gameObject);
                }
            }
        }
    }

}
