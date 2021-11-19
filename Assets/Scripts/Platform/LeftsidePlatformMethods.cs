using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftsidePlatformMethods : MonoBehaviour
{
    public GameObject[] prefabs;
    public float platformGap = 16.74f;
    private bool spawned;

    private GameObject cam;
    
    private bool moved;

    private float smoothTime = .2f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 startPos;
    private Vector3 targetPos;




    private void Awake()
    {
        spawned = false;
        moved = false;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CrumblingStarter") && spawned == false)
        {
            spawnPlatfrom();
            StartCoroutine("startCrumbling", 2f);
            spawned = true;
            moved = true;

        }
    }

    private void FixedUpdate()
    {
        if (moved)
        {
            startPos = cam.transform.position;
            targetPos = new Vector3(startPos.x, gameObject.transform.position.y, startPos.z);
            MoveCam();

        }
        if (startPos == targetPos)
        {
            moved = false;
        }


    }

    private void MoveCam()
    {
        
        cam.transform.position = Vector3.SmoothDamp(startPos, targetPos, ref velocity, smoothTime);
        

    }

    private void spawnPlatfrom()
    {
        var prefabIndex = Random.Range(0, prefabs.Length);
        var positionX = Random.Range(-5.5f, -2f);
        var position = new Vector3(positionX, this.gameObject.transform.position.y + platformGap, prefabs[prefabIndex].transform.position.z);

        Instantiate(prefabs[prefabIndex], position, prefabs[prefabIndex].transform.rotation);
    }

    IEnumerator startCrumbling()
    {
        //play the first crumbling animation
        yield return new WaitForSeconds(3f);
        //play the second crumbling animation
        yield return new WaitForSeconds(3f);
        //play the last crumbling animation with particles by using instantiate method
        //and then destroy the gameObject all together


    }

}
