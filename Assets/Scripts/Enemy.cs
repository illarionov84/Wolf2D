using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class Enemy : BaseObject
    {
        [SerializeField] private int _health;

        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                if (_health <= 0 && !dead)
                {
                    StartCoroutine(State_Death());
                }
            }
        }

        [SerializeField] private bool active;
        public AI_ENEMY_STATE currentState = AI_ENEMY_STATE.IDLE;
        public float AttackDelay;
        private bool right;
        private Vector2 playerPos;
        private Vector3 direction;
        private float speed;
        public LayerMask mask;
        public float X;
        public float Y;
        public float rayDistance;
        public Bullet enemyBulletPref;
        public Animator anim;
        public AudioSource _audio;
        public AudioClip[] audioClips;
        public bool CanSeePlayer;
        private RaycastHit2D hit;
        public bool dead;

        void Awake()
        {
            Health = 3;
            speed = 1.0f;
            X = -1.0f;
            Y = 0.0f;
            direction = Vector3.left;
            anim = GetComponent<Animator>();
            _audio = GetComponent<AudioSource>();
            _audio.clip = audioClips[0];
            CanSeePlayer = false;
            dead = false;
        }

        private void Start()
        {
            StartCoroutine(State_Idle());
        }

        void Flip()
        {
            right = !right;
            Vector2 sc = transform.localScale;
            sc.x *= -1;
            X *= -1;
            direction.x *= -1;
            transform.localScale = sc;
        }

        /*
        private void FixedUpdate()
        {
            if (active)
            {
                hit = Physics2D.Raycast(transform.position, new Vector2(X, Y), rayDistance, mask);
                Debug.DrawRay(transform.position, new Vector2(X, Y), Color.red);
            }
        }
        */

        public override void OnFixedTick()
        {
            if (active)
            {
                hit = Physics2D.Raycast(transform.position, new Vector2(X, Y), rayDistance, mask);
                Debug.DrawRay(transform.position, new Vector2(X, Y), Color.red);
            }
        }

        private void OnBecameInvisible()
        {
            active = false;
        }

        private void OnBecameVisible()
        {
            active = true;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerPos = collision.transform.position;
                CanSeePlayer = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                CanSeePlayer = false;
            }
        }

        Vector2 GetDirection()
        {
            if (transform.position.x < playerPos.x)
            {
                return Vector2.right;
            }
            else
            {
                return Vector2.left;
            }
        }

        void Move()
        {
            transform.position =
                Vector2.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        }

        void Shoot()
        {
            Bullet bullet = Instantiate(enemyBulletPref, transform.position, Quaternion.identity);
            bullet.name = "EnemyBullet";
            if (right)
            {
                bullet.direction = 1;
            }
            else
            {
                bullet.direction = -1;
            }

            _audio.Play();
        }

        //--------------------------------------------------

        #region States

        //--------------------------------------------------

        public IEnumerator State_Idle()
        {
            currentState = AI_ENEMY_STATE.IDLE;
            anim.SetInteger("State", 0);
            _audio.Stop();
            while (currentState == AI_ENEMY_STATE.IDLE)
            {
                if (active)
                {
                    StartCoroutine(State_Patrol());
                    yield break;
                }

                yield return null;
            }
        }

        public IEnumerator State_Patrol()
        {
            currentState = AI_ENEMY_STATE.PATROL;
            anim.SetInteger("State", 1);
            _audio.Stop();
            while (currentState == AI_ENEMY_STATE.PATROL)
            {
                Y = 0.0f;
                rayDistance = 0.5f;
                if (hit.collider)
                {
                    Flip();
                }
                else
                {
                    Move();
                }

                if (CanSeePlayer)
                {
                    StartCoroutine(State_Attack());
                    yield break;
                }

                yield return null;
            }
        }

        public IEnumerator State_Chase()
        {
            //

            yield return null;
        }

        public IEnumerator State_Attack()
        {
            currentState = AI_ENEMY_STATE.ATTACK;
            anim.SetInteger("State", 2);
            while (currentState == AI_ENEMY_STATE.ATTACK)
            {
                if (!CanSeePlayer)
                {
                    StartCoroutine(State_Patrol());
                    yield break;
                }

                yield return null;
            }
        }

        public IEnumerator State_Death()
        {
            dead = true;
            currentState = AI_ENEMY_STATE.DEATH;
            gameObject.layer = 10;
            anim.SetInteger("State", 5);
            _audio.Stop();
            yield return null;
        }

        //--------------------------------------------------

        #endregion

        //--------------------------------------------------

    }

}
