using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator2 : MonoBehaviour
{
    // [Range(1.0f, 10.0f)]
    // public float speed = 1.0f;
    // public float riseHeight = 5.0f;
    // public float traverseRightLength = 0.0f;
    // public float travelTime;
    // // private Variables
    // private Vector3 _startPos;
    // private Vector3 _endPos;
    // private float startTime;
    // private float travelLength;
    // //new
    // private Rigidbody2D body;
    // private Vector3 _travelDirection;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     body = GetComponent<Rigidbody2D>();
        
    //     _startPos = transform.position;
        
    //     // set the end marker to be from where the elevator starts to how much it should move on x and y axis
    //     _endPos = new Vector3(transform.position.x + traverseRightLength, transform.position.y + riseHeight, transform.position.z);
    //     startTime = Time.time;
    //     travelLength = Vector3.Distance(_startPos, _endPos);

    //     _travelDirection = Vector3.Normalize((_endPos - _startPos));
    //     body.velocity = _travelDirection * speed;
    // }

    // void FixedUpdate()
    // {
    //     // float distanceCovered = (Time.time - startTime) * speed;
    //     // float fraction = distanceCovered / travelLength;
    //     // transform.position = Vector3.Lerp(_startPos, _endPos, fraction);
        
    //     if((Time.time - startTime) >= travelTime)
    //     {
    //         var dirTmp = body.velocity;
    //         body.velocity = new Vector3(0f, 0f, 0f);
    //         var tmp = _startPos;
    //         _startPos = _endPos;
    //         _endPos = tmp;
    //         body.velocity = -dirTmp;
    //         startTime = Time.time;
    //     }
    // }

    // private void OnCollisionEnter2D(Collision2D col)
    // {
    //     if(col.gameObject.tag == "Player1")
    //     {
    //         col.collider.transform.SetParent(transform);
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D col)
    // {
    //     if(col.gameObject.tag == "Player1")
    //     {
    //         col.collider.transform.SetParent(null);
    //     }
    // }

    //! Lerp Script
    
    //     [Range(1.0f, 10.0f)]
    // public float speed = 1.0f;
    // public float riseHeight = 5.0f;
    // public float traverseRightLength = 0.0f;
    // public GameObject player;
    // // private Variables
    // private Vector3 _startPos;
    // private Vector3 _endPos;
    // private float startTime;
    // private float travelLength;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     _startPos = transform.position;
    //     // set the end marker to be from where the elevator starts to how much it should move on x and y axis
    //     _endPos = new Vector3(transform.position.x + traverseRightLength, transform.position.y + riseHeight, transform.position.z);
    //     startTime = Time.time;
    //     travelLength = Vector3.Distance(_startPos, _endPos);
    // }

    // void FixedUpdate()
    // {
    //     float distanceCovered = (Time.time - startTime) * speed;
    //     float fraction = distanceCovered / travelLength;
    //     transform.position = Vector3.Lerp(_startPos, _endPos, fraction);

    //     if(transform.position == _endPos)
    //     {
    //         var tmp = _startPos;
    //         _startPos = _endPos;
    //         _endPos = tmp;
    //         startTime = Time.time;
    //     }
    // }

    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     if(col.gameObject == player)
    //     {
    //         player.transform.parent = this.transform;
    //         // player.transform.SetParent(transform, false);
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D col)
    // {
    //     if(col.gameObject == player)
    //     {
    //         player.transform.parent = null;
    //     }
    // }
    
    //! Frá Mikael
    public Vector3 deltaPosition;
        public bool continuous = false;
        public bool startActive = false;
        public float speed = 0.5f;
        public float edgeWait = 0.5f;

        private bool isActive;
        private Vector3 startingLocation;
        private Vector3 targetLocation;
        private float edgeTimer;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            isActive = startActive;
            startingLocation = transform.position;
            targetLocation = startingLocation + deltaPosition;
            edgeTimer = edgeWait;
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(isActive)
                transform.position = Vector3.MoveTowards(transform.position, targetLocation, speed);
            if(continuous && targetLocation == transform.position && (edgeTimer = edgeTimer - Time.deltaTime) <= 0.0f)
            {
                Vector3 tmp = startingLocation;
                startingLocation = targetLocation;
                targetLocation = tmp;
                edgeTimer = edgeWait;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player1"))
            {
                other.gameObject.transform.parent = this.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player1") && other.gameObject.transform.parent == this.transform)
            {
                other.gameObject.transform.parent = null;
            }
        }

        public void StartMoving()
        {
            isActive = true;
        }
}
