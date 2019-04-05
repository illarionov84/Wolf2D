using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGun : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject temp = collision.gameObject;
            temp.GetComponent<Player>().ChainGun = true;
            Destroy(gameObject);
        }
    }
}
