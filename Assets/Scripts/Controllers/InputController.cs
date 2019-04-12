using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class InputController : BaseObject
    {
        private float horizontal;

        private UIController UIController;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            UIController = GameObject.Find("Canvas").GetComponent<UIController>();
        }

        public override void OnTick()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIController.ShowMenu();
            }

            horizontal = Input.GetAxis("Horizontal");

            if (Input.GetButton("Horizontal"))
            {
                //Событие: нажали на стрелки перемещения
            }

            if (Input.GetButtonDown("Fire1"))
            {
                //Событие: нажали на кнопку стрельбы
            }
        }
    }

}
