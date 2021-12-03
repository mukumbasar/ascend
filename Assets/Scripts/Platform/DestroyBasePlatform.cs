using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBasePlatform : MonoBehaviour
{
    public GameObject basePlatform;

    public Rigidbody2D rb;

    private AudioSource cracking;

    private bool ifCondition;

    private void Awake()
    {
        cracking = gameObject.GetComponent<AudioSource>();
        ifCondition = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CrumblingStarter") && ifCondition)
        {

            StartCoroutine("startBaseCrumbling");


        }
    }
    IEnumerator startBaseCrumbling()
    {
        ifCondition = false;
        yield return new WaitForSeconds(1);
        Destroy(basePlatform);
        cracking.Play(); 
        yield return new WaitForSeconds(3.5f);
        Destroy(gameObject);
    }
}