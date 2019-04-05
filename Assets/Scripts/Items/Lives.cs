using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject temp = collision.gameObject;
            temp.GetComponent<Player>().Lives++;
            temp.GetComponent<Player>().Health = 100;
            temp.GetComponent<Player>().Ammo = 99;
            Destroy(gameObject);
        }
    }
}
