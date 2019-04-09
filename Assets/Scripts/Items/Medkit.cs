using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class Medkit : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (collision.GetComponent<Player>().Health < 100)
                {
                    collision.GetComponent<Player>().Health += 25;
                    Destroy(gameObject);
                }
            }
        }
    }

}
