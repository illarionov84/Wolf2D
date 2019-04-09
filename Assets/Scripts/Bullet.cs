using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class Bullet : BaseObject
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

        /*
        void Update()
        {
            transform.position += Vector3.right * direction * speed;
        }
        */

        public override void OnTick()
        {
            transform.position += Vector3.right * direction * speed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (playerBullet)
            {
                if (collision.gameObject.CompareTag("Enemy"))
                {
                    collision.GetComponent<Enemy>().Health--;
                    Destroy(gameObject);
                }
            }
            else
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    collision.GetComponent<Player>().Health--;
                    Destroy(gameObject);
                }
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject, 3.0f);
        }
    }

}
