using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private bool right;
    private bool active;
    public bool angry;
    public bool patrol;
    public bool shooting;
    private Vector2 playerPos;
    private Vector3 direction;
    private float speed;
    public LayerMask mask;
    public float X;
    public float Y;
    public float rayDistance;
    public float attackDistance;
    public GameObject enemyBulletPref;

    void Start()
    {
        health = 3;
        speed = 1.0f;
        X = -0.5f;
        Y = -0.5f;
        direction = Vector3.left;
        patrol = true;
        attackDistance = 3.0f;
    }

    void Flip()
    {
        right = !right;
        Vector2 sc = transform.localScale;
        sc.x *= -1;
        X *= -1;
        direction.x *= -1;
        transform.localScale = sc;
    }

    IEnumerator enemyShoot()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(enemyBulletPref, transform.position, Quaternion.identity);
            temp.name = "EnemyBullet";
            if (right)
            {
                temp.GetComponent<Bullet>().direction = 1;
            }
            else
            {
                temp.GetComponent<Bullet>().direction = -1;
            }
            yield return new WaitForSeconds(1);
        }
        shooting = false;
    }

    private void FixedUpdate()
    {
        if (active)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(X, Y), rayDistance, mask);
            Debug.DrawRay(transform.position, new Vector2(X, Y), Color.red);

            if (patrol)
            {
                Y = -0.5f;
                rayDistance = 1.0f;
                if (hit.collider)
                {
                    Debug.Log(hit.collider.name);
                    Move();
                }
                else
                {
                    Flip();
                }
            }
            else
            {
                Y = 0;
                rayDistance = attackDistance;
                if (Mathf.Abs(transform.position.x - playerPos.x) <= rayDistance)
                {
                    if (hit.collider)
                    {
                        if (hit.collider.tag == "Player" && shooting == false)
                        {
                            StartCoroutine(enemyShoot());
                            shooting = true;
                        }
                    }
                }
                else
                {
                    direction = GetDirection();
                    Move();
                }
            }

            if (hit != false)
            {
                Debug.Log(hit.collider.name);
            }
        }
    }

    private void OnBecameInvisible()
    {
        active = false;
    }

    private void OnBecameVisible()
    {
        active = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerPos = collision.transform.position;
            angry = true;
            patrol = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            patrol = true;
            angry = false;
        }
    }

    Vector2 GetDirection()
    {
        if (transform.position.x < playerPos.x)
        {
            return Vector2.right;
        }
        else
        {
            return Vector2.left;
        }
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    void Update()
    {
        if (transform.position.y < -10 || health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
