using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightsidePlatformMethods : MonoBehaviour
{
    public GameObject[] prefabs;
    public float platformGap = 16.74f;
    private bool spawned;

    private GameObject cam;
    public float camMoveSpeed = 2f;
    private bool moved;

    

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

    private void Update()
    {
        if (moved)
        {
            var currentCamPos = cam.transform.position;
            var newCamPos = new Vector3(cam.transform.position.x, this.gameObject.transform.position.y, cam.transform.position.z);
            cam.transform.position = newCamPos;
            moved = false;
        }
        
    }
    private void spawnPlatfrom()
    {
        var prefabIndex = Random.Range(0, prefabs.Length);
        var positionX = Random.Range(1, 5.5f);
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
