using System.Collections;
using UnityEngine;

namespace Wolf2D
{

    public class ExitLevel : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                LevelController.Instance.hitEventLevelComplete.Invoke();
            }
        }
    }

}
