using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private bool _isDown;
    public bool IsDown
    {
        get { return _isDown; }
        set
        {
            _isDown = value;
            if (_isDown && !processed)
            {
                StartCoroutine(Door_Close());
            }
            else if (!_isDown && !processed)
            {
                StartCoroutine(Door_Open());
            }
        }
    }
    public bool processed;
    public bool canOpened;
    public Vector2 currentPos;
    public Vector2 closedPos;
    public Vector2 openedPos;
    public float speed;
    public AudioSource _audio;
    public AudioClip[] audioClips;

    void Awake()
    {
        processed = false;
        currentPos = transform.position;
        if (IsDown)
        {
            closedPos = currentPos;
            openedPos = new Vector2(transform.position.x, transform.position.y + 2);
        }
        else
        {
            closedPos = new Vector2(transform.position.x, transform.position.y - 2);
            openedPos = currentPos;
        }
        speed = 2.0f;
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canOpened = true;
            collision.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canOpened = false;
            collision.transform.parent = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canOpened)
        {
            IsDown = !IsDown;
        }
    }

    public IEnumerator Door_Open()
    {
        processed = true;
        //_audio.clip = audioClips[0];
        //_audio.Play();
        while (currentPos != openedPos)
        {
            currentPos = transform.position;
            transform.position = Vector2.MoveTowards(currentPos, openedPos, speed * Time.deltaTime);
            yield return null;
        }
        processed = false;
    }

    public IEnumerator Door_Close()
    {
        processed = true;
        //_audio.clip = audioClips[1];
        //_audio.Play();
        while (currentPos != closedPos)
        {
            currentPos = transform.position;
            transform.position = Vector2.MoveTowards(currentPos, closedPos, speed * Time.deltaTime);
            yield return null;
        }
        processed = false;
    }
}
