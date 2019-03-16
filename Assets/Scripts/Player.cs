using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Collider2D Coll;
    public Vector3 direction;
    public int speed;
    public float horizontal;
    bool right;
    public SpriteRenderer rend;
    public int health;
    public GameObject prefBullet;
    public Transform gunPos;

    void Start()
    {
        speed = 4;
        rend = GetComponent<SpriteRenderer>();
        health = 10;
        gunPos = transform.GetChild(0);
    }

    void Shoot()
    {
        GameObject temp = Instantiate(prefBullet, gunPos.position, Quaternion.identity);
        temp.name = "Bullet";
        temp.GetComponent<Bullet>().direction = (!right) ? 1 : -1;
    }

    void Move()
    {
        if (horizontal > 0 && right)
        {
            Flip();
        }
        else if (horizontal < 0 && !right)
        {
            Flip();
        }

        direction = Vector3.right * horizontal;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    void Flip()
    {
        right = !right;
        Vector2 sc = transform.localScale;
        sc.x *= -1;
        transform.localScale = sc;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButton("Horizontal"))
        {
            Move();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        
        if (transform.position.y < -10 || health <=0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
