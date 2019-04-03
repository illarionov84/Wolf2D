using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AI_ENEMY_STATE {IDLE = 0,
                            PATROL = 1,
                            CHASE = 2,
                            ATTACK = 3,
                            DEATH = 5};

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            //Messenger.Broadcast(GameEvent.HEALTH_UPDATED);
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
    public GameObject enemyBulletPref;
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
        X = -0.5f;
        Y = -0.5f;
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

    private void FixedUpdate()
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
        if (collision.gameObject.tag == "Player")
        {
            playerPos = collision.transform.position;
            CanSeePlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
        transform.position = Vector2.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    void Shoot()
    {
        GameObject temp = Instantiate(enemyBulletPref, transform.position, Quaternion.identity);
        temp.name = "EnemyBullet";
        if (right)
        {
            temp.GetComponent<Bullet>().direction = 1;
        }
        else
        {
            temp.GetComponent<Bullet>().direction = -1;
        }
        _audio.Play();
    }

    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
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
            Y = -1.0f;
            rayDistance = 2.0f;
            if (hit.collider)
            {
                Move();
            }
            else
            {
                Flip();
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
        anim.SetInteger("State", 5);
        _audio.Stop();
        yield return null;
    }

    //--------------------------------------------------
    #endregion
    //--------------------------------------------------

}
