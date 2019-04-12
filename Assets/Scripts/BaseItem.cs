using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public abstract class BaseItem : MonoBehaviour
    {
        public Collider2D coll;
        public bool isDestroy = true;

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                coll = collision;
                Action();
                if (isDestroy) Destroy(gameObject);
            }
        }

        public abstract void Action();
    }

}
