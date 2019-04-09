using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf2D
{

    public class Door : BaseObject
    {
        [SerializeField] private bool _isClosed;

        public bool IsClosed
        {
            get { return _isClosed; }
            set
            {
                _isClosed = value;
                if (_isClosed && !processed)
                {
                    StartCoroutine(Door_Close());
                }
                else if (!_isClosed && !processed)
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
        public GameObject door;
        public AudioSource _audio;
        public AudioClip[] audioClips;

        void Awake()
        {
            _isClosed = true;
            processed = false;
            currentPos = door.transform.position;
            closedPos = currentPos;
            openedPos = new Vector2(door.transform.position.x, door.transform.position.y + 1);
            speed = 2.0f;
            _audio = GetComponent<AudioSource>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                canOpened = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                canOpened = false;
            }
        }

        /*
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && canOpened)
            {
                IsClosed = !IsClosed;
            }
        }
        */

        public override void OnTick()
        {
            if (Input.GetKeyDown(KeyCode.Space) && canOpened)
            {
                IsClosed = !IsClosed;
            }
        }

        public IEnumerator Door_Open()
        {
            processed = true;
            _audio.clip = audioClips[0];
            _audio.Play();
            while (currentPos != openedPos)
            {
                currentPos = door.transform.position;
                door.transform.position = Vector2.MoveTowards(currentPos, openedPos, speed * Time.deltaTime);
                yield return null;
            }

            processed = false;
        }

        public IEnumerator Door_Close()
        {
            processed = true;
            _audio.clip = audioClips[1];
            _audio.Play();
            while (currentPos != closedPos)
            {
                currentPos = door.transform.position;
                door.transform.position = Vector2.MoveTowards(currentPos, closedPos, speed * Time.deltaTime);
                yield return null;
            }

            processed = false;
        }
    }

}
