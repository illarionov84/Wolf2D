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
            speed = 0.03f;
            damage = 2;
        }

        public override void OnTick()
        {
            transform.position += Vector3.right * direction * speed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && gameObject.name == "PlayerBullet")
            {
            collision.GetComponent<Enemy>().Health--;
            gameObject.SetActive(false);
            }
            else if (collision.gameObject.CompareTag("Player") && gameObject.name == "EnemyBullet")
            {
            collision.GetComponent<Player>().Health--;
            gameObject.SetActive(false);
            }
        }

        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }
    }

}
