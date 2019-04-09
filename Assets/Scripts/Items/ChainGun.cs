using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class ChainGun : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.GetComponent<Player>().ChainGun = true;
                Destroy(gameObject);
            }
        }
    }

}
