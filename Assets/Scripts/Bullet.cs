using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    public int damage;
    public int direction;

    private void Start()
    {
        speed = 0.3f;
        damage = 2;
    }

    void Update()
    {
        transform.position += Vector3.right * direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject temp = collision.gameObject;
            temp.GetComponent<Enemy>().health--;
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 3.0f);
    }
}
