using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    void Start()
    {
        health = 10;
    }

    void Update()
    {
        if (transform.position.y < -10 || health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
