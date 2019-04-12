using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Wolf2D
{

    public class UIController : BaseObject
    {
        [SerializeField] public Text _level;

        public string Level
        {
            get { return _level.text; }
            set { _level.text = value; }
        }

        [SerializeField] private Text _scores;

        public string Scores
        {
            get { return _scores.text; }
            set { _scores.text = value; }
        }

        [SerializeField] private Text _lives;

        public string Lives
        {
            get { return _lives.text; }
            set { _lives.text = value; }
        }

        [SerializeField] private Text _health;

        public string Health
        {
            get { return _health.text; }
            set { _health.text = value; }
        }

        [SerializeField] private Text _ammo;

        public string Ammo
        {
            get { return _ammo.text; }
            set { _ammo.text = value; }
        }

        [SerializeField] private bool _goldKey = false;

        public bool GoldKey
        {
            get { return _goldKey; }
            set { _goldKey = value; }
        }

        [SerializeField] private bool _silverKey = false;

        public bool SilverKey
        {
            get { return _silverKey; }
            set { _silverKey = value; }
        }

        [SerializeField] private bool _machineGun = false;

        public bool MachineGun
        {
            get { return _machineGun; }
            set { _machineGun = value; }
        }

        [SerializeField] private bool _chainGun = false;

        public bool ChainGun
        {
            get { return _chainGun; }
            set { _chainGun = value; }
        }

        public GameObject MainMenu;
        public GameObject Options;
        public GameObject HUD;
        public Image CanvasBack;
        private bool IsShowMenu;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            MainMenu.SetActive(true);
            Options.SetActive(false);
            HUD.SetActive(false);
            IsShowMenu = true;
            CanvasBack = GetComponent<Image>();
        }

        public void ShowMenuMain()
        {
            MainMenu.SetActive(true);
            Options.SetActive(false);
            HUD.SetActive(false);
            CanvasBack.enabled = true;
            Time.timeScale = 0.0f;
        }

        public void ShowMenuOptions()
        {
            MainMenu.SetActive(false);
            Options.SetActive(true);
            HUD.SetActive(false);
            CanvasBack.enabled = true;
        }

        public void ShowHUD()
        {
            MainMenu.SetActive(false);
            Options.SetActive(false);
            HUD.SetActive(true);
            CanvasBack.enabled = false;
            Time.timeScale = 1.0f;
        }

        public void NewGame()
        {
            ShowHUD();
            LevelController.Instance.hitEventLevelComplete.Invoke();
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void ShowMenu()
        {
            if (IsShowMenu)
            {
                ShowMenuMain();
            }
            else
            {
                ShowHUD();
            }

            IsShowMenu = !IsShowMenu;
        }
    }

}
