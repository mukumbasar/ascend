using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMethods : MonoBehaviour
{
    public GameObject[] prefabs;
    public float platformGap = 8.37f;

    private void Awake()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CrumblingStarter"))
        {
            spawnPlatfrom();
            StartCoroutine("startCrumbling", 2f);
        }
    }

    private void spawnPlatfrom()
    {
        var prefabIndex = Random.Range(0, prefabs.Length);
        var positionX = Random.Range(-5.68f, 5.76f);
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
