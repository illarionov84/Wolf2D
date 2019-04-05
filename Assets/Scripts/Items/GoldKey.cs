using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKey : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject temp = collision.gameObject;
            temp.GetComponent<Player>().GoldKey = true;
            Destroy(gameObject);
        }
    }
}
