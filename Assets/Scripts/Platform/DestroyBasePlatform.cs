using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBasePlatform : MonoBehaviour
{
    public GameObject basePlatform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CrumblingStarter"))
        {

            StartCoroutine("startBaseCrumbling");


        }
    }
    IEnumerator startBaseCrumbling()
    {
        yield return new WaitForSeconds(2);
        Destroy(basePlatform);
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }
}