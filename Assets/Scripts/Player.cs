using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Collider2D Coll;
    public Vector3 direction;
    public float speed;
    public float horizontal;
    private bool right;
    public SpriteRenderer rend;
    public int health;
    public GameObject prefBullet;
    public Transform gunPos;
    public Rigidbody2D _rigidbody;
    public int jumpForce;
    public bool ground;
    private Camera mainCam;
    public float camSpeed;

    void Start()
    {
        speed = 4.0f;
        rend = GetComponent<SpriteRenderer>();
        health = 10;
        gunPos = transform.GetChild(0);
        _rigidbody = GetComponent<Rigidbody2D>();
        jumpForce = 3;
        mainCam = Camera.main;
        camSpeed = 3.0f;
    }

    void Shoot()
    {
        GameObject temp = Instantiate(prefBullet, gunPos.position, Quaternion.identity);
        temp.name = "Bullet";
        temp.GetComponent<Bullet>().direction = (!right) ? 1 : -1;
    }

    void Jump()
    {
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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

        direction = Vector2.right * horizontal;
        transform.position = Vector2.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    void Flip()
    {
        right = !right;
        Vector2 sc = transform.localScale;
        sc.x *= -1;
        transform.localScale = sc;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            ground = false;
        }
    }

    void Update()
    {
        mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, new Vector3(transform.position.x, transform.position.y + 0.5f, mainCam.transform.position.z), Time.deltaTime * camSpeed);

        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButton("Horizontal"))
        {
            Move();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && ground)
        {
            Jump();
        }

        if (transform.position.y < -4.0f || health <=0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
