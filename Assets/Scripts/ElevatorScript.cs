using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AGDDPlatformer
{
    public class ElevatorScript : MonoBehaviour
    {
        public Vector3 deltaPos;
        public float speed = 0.5f;
        public bool startAwake = true;
        private Vector3 _startPos;
        private Vector3 _endPos;

        private float startTime;
        private float travelLength;
        private bool moving;

        /// Awake is called when the script instance is being loaded.
        void Awake()
        {
            _startPos = transform.position;
            _endPos = _startPos + deltaPos;
            travelLength = Vector3.Distance(_startPos, _endPos);
            moving = startAwake;
        }

        // Start is called before the first frame update
        void Start()
        {
            if(startAwake)
            {
                startTime = Time.time;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(moving)
            {
                float distanceCovered = (Time.time - startTime) * speed;
                float fraction = distanceCovered / travelLength;
                transform.position = Vector3.Lerp(_startPos, _endPos, fraction);

                if(_endPos == transform.position)
                {
                    Vector3 tmp = _startPos;
                    _startPos = _endPos;
                    _endPos = tmp;
                    startTime = Time.time;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.tag == "Player1")
            {
                if(!moving)
                {
                    moving = true; 
                    startTime = Time.time;
                }

                col.gameObject.transform.parent = this.transform;
                this.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f);
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if(col.gameObject.tag == "Player1")
            {
                col.gameObject.transform.parent = null;
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 1.0f);
            }
        }
    }
}