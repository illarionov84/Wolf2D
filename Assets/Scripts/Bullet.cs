using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    public int damage;
    public int direction;
    public bool playerBullet;

    private void Start()
    {
        speed = 0.3f;
        damage = 2;
        if (gameObject.name == "Bullet")
        {
            playerBullet = true;
        }
        else
        {
            playerBullet = false;
        }
    }

    void Update()
    {
        transform.position += Vector3.right * direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerBullet)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameObject temp = collision.gameObject;
                temp.GetComponent<Enemy>().health--;
                Destroy(gameObject);
                Debug.Log("Попал во врага");
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                GameObject temp = collision.gameObject;
                temp.GetComponent<Player>().health--;
                Destroy(gameObject);
                Debug.Log("Попал в игрока");
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 3.0f);
    }
}
