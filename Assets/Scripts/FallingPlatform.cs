using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float waitTime = 1.0f;
    public float dropDeltaY = 30.0f;
    public float respawnTime = 1.0f;
    public Transform platformPrefab;
    public GameObject platform;

    // private variables
    private bool doOnce = false;
    private Vector3 startPos;
    private float dropInterval;

    void Awake()
    {
        platform = transform.GetChild(0).gameObject;
        startPos = platform.transform.position;
        dropInterval = 0.0005f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player1")
        {
            Debug.Log("Collision!");
            doOnce = true;
        }
        
        if (doOnce)
        {
            StartCoroutine("DropPlatform");
            doOnce = false;
        }
    }

    private IEnumerator DropPlatform()
    {

        yield return new WaitForSeconds(waitTime);

        Vector3 pos = transform.position;
        while(pos.y > (startPos.y - dropDeltaY))
        {
            pos.y -= 0.25f;
            platform.transform.position = pos;
            yield return new WaitForSeconds(dropInterval);
        }

        Destroy(platform);
        
        yield return new WaitForSeconds(respawnTime);

        platform = Instantiate(platformPrefab.gameObject);
        platform.transform.position = startPos;


    }
}
