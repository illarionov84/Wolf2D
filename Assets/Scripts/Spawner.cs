using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPref;
    public GameObject currentEnemy;

    void Start()
    {
        CreateEnemy(enemyPref[0]);
    }

    void CreateEnemy(GameObject Enemy)
    {
        currentEnemy = Instantiate(Enemy, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (currentEnemy==null)
        {
            CreateEnemy(enemyPref[0]);
        }
    }
}
