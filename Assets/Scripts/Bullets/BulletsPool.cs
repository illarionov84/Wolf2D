using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class BulletsPool : Singleton<BulletsPool>
    {
        public GameObject prefBullet;
        public int bulletsPoolSize = 10;

        private List<GameObject> bullets;

        private void Awake()
        {
            DontDestroyOnLoad(this);

            bullets = new List<GameObject>();
            for (int i = 0; i < bulletsPoolSize; i++)
            {
                GameObject bullet = (GameObject) Instantiate(prefBullet);
                bullet.transform.parent = transform.root;
                bullet.SetActive(false);
                bullets.Add(bullet);
            }
        }

        public GameObject GetBullet()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    bullets[i].SetActive(true);
                    return bullets[i];
                }
            }

            return null;
        }
    }

}
