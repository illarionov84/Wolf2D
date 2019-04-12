using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Wolf2D
{

    public class Player : BaseObject
    {
        private UIController HUD;

        [SerializeField] private int _scores;

        public int Scores
        {
            get { return _scores; }
            set
            {
                _scores = value;
                HUD.Scores = _scores.ToString();
            }
        }

        [SerializeField] private int _lives;

        public int Lives
        {
            get { return _lives; }
            set
            {
                if (value > 99) _lives = 10;
                else if (value < 0) _lives = 0;
                else _lives = value;
                HUD.Lives = _lives.ToString();
            }
        }

        [SerializeField] private int _health;

        public int Health
        {
            get { return _health; }
            set
            {
                if (value > 100) _health = 100;
                else if (value < 0) _health = 0;
                else _health = value;
                HUD.Health = _health.ToString();
                if (_health <= 0)
                {
                    LevelController.Instance.hitEventLevelFailed.Invoke();
                }
            }
        }

        [SerializeField] private int _ammo;

        public int Ammo
        {
            get { return _ammo; }
            set
            {
                if (value > 99) _ammo = 99;
                else if (value < 0) _ammo = 0;
                else _ammo = value;
                HUD.Ammo = _ammo.ToString();
            }
        }

        [SerializeField] private bool _goldKey;

        public bool GoldKey
        {
            get { return _goldKey; }
            set { _goldKey = value; }
        }

        [SerializeField] private bool _silverKey;

        public bool SilverKey
        {
            get { return _silverKey; }
            set { _silverKey = value; }
        }

        [SerializeField] private bool _machineGun;

        public bool MachineGun
        {
            get { return _machineGun; }
            set { _machineGun = value; }
        }

        [SerializeField] private bool _chainGun;

        public bool ChainGun
        {
            get { return _chainGun; }
            set { _chainGun = value; }
        }

        [SerializeField] private CURRENT_WEAPON _currentWeapon;

        public CURRENT_WEAPON CurrentWeapon
        {
            get { return _currentWeapon; }
            set { _currentWeapon = value; }
        }

        public PLAYER_STATE currentState = PLAYER_STATE.IDLE;
        private Vector3 direction;
        private float speed;
        private float horizontal;
        private bool right;
        private SpriteRenderer rend;
        public Bullet prefBullet;
        private Transform gunPos;
        private Rigidbody2D _rigidbody;
        private Camera mainCam;
        private float camSpeed;
        private Animator anim;
        private AudioSource _audio;
        public AudioClip[] audioClips;

        void Awake()
        {
            HUD = GameObject.Find("Canvas").GetComponent<UIController>();
            speed = 1.5f;
            rend = GetComponent<SpriteRenderer>();
            Lives = 3;
            Health = 100;
            Ammo = 8;
            gunPos = transform.GetChild(0);
            _rigidbody = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            _audio = GetComponent<AudioSource>();
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            camSpeed = 3.0f;
        }

        private void Start()
        {
            anim.SetInteger("State", 0);
        }

        void Shoot()
        {
            Ammo--;
            currentState = PLAYER_STATE.ATTACK;
            GameObject bullet= BulletsPool.Instance.GetBullet();
            bullet.transform.position = gunPos.position;
            bullet.GetComponent<Bullet>().name = "PlayerBullet";
            bullet.GetComponent<Bullet>().direction = (!right) ? 1 : -1;
            _audio.clip = audioClips[0];
            _audio.Play();
        }

        void Move()
        {
            currentState = PLAYER_STATE.MOVE;
            anim.SetInteger("State", 1);
            if (horizontal > 0 && right)
            {
                Flip();
            }
            else if (horizontal < 0 && !right)
            {
                Flip();
            }

            direction = Vector2.right * horizontal;
            transform.position =
                Vector2.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        }

        void Flip()
        {
            right = !right;
            Vector2 sc = transform.localScale;
            sc.x *= -1;
            transform.localScale = sc;
        }

        public override void OnTick()
        {
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position,
                new Vector3(transform.position.x, transform.position.y + 0.5f, mainCam.transform.position.z),
                Time.deltaTime * camSpeed);

            horizontal = Input.GetAxis("Horizontal");

            currentState = PLAYER_STATE.IDLE;
            anim.SetInteger("State", 0);

            if (Input.GetButton("Horizontal"))
            {
                Move();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetInteger("State", 2);
            }
        }
    }

}