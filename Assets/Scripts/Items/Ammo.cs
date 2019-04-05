using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject temp = collision.gameObject;
            if (temp.GetComponent<Player>().Ammo < 99)
            {
                temp.GetComponent<Player>().Ammo += 8;
                Destroy(gameObject);
            }
        }
    }
}
