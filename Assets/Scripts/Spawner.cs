using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPref;
    public GameObject currentEnemy;

    void Start()
    {
        CreateEnemy(enemyPref[Random.Range(0, enemyPref.Length)]);
    }

    void CreateEnemy(GameObject Enemy)
    {
        currentEnemy = Instantiate(Enemy, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (currentEnemy==null)
        {
            transform.position = new Vector3(Random.Range(-10.0f, 10.0f), transform.position.y, transform.position.z);
            CreateEnemy(enemyPref[Random.Range(0, enemyPref.Length)]);
        }
    }
}
