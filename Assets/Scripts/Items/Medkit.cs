using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject temp = collision.gameObject;
            if (temp.GetComponent<Player>().Health < 100)
            {
                temp.GetComponent<Player>().Health += 25;
                Destroy(gameObject);
            }
        }
    }
}
