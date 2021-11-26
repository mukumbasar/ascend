using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RightsidePlatformMethods : MonoBehaviour
{
    public GameObject[] prefabs;
    public float platformGap = 9.64f;
    private bool spawnedPlatform;

    private GameObject cam;
    
    private bool moved;

    private float smoothTime = .1f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 startPos;
    private Vector3 targetPos;

    // getting to the child object that contains the sprite
    private SpriteRenderer leftChildSpriteRenderer;
    public Sprite leftDamagedSprite;

    //score text and activating it
    private GameObject scoreText;
    private bool spawnedText;
    private float newScore;

    private void Awake()
    {
        spawnedPlatform = false;
        moved = false;
        spawnedText = false;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        leftChildSpriteRenderer = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CrumblingStarter") && spawnedPlatform == false && spawnedText == false)
        {
            spawnPlatfrom();
            StartCoroutine("startCrumbling");

            scoreText = GameObject.Find("Score Text");
            scoreText.GetComponent<TextMeshProUGUI>().enabled = true;



            spawnedPlatform = true;
            spawnedText = true;
            moved = true;

        }
    }

    private void FixedUpdate()
    {
        if (moved)
        {
            var offset = 5f;
            startPos = cam.transform.position;
            targetPos = new Vector3(startPos.x, (gameObject.transform.position.y + offset), startPos.z);
            MoveCam();

        }
        if (startPos == targetPos)
        {
            moved = false;
        }
        if (spawnedText)
        {
            scoreCounter();
            Debug.Log("counted");
            spawnedText = false;
        }
    }

    private void scoreCounter()
    {
        newScore = float.Parse(scoreText.GetComponent<TextMeshProUGUI>().text);
        newScore++;
        scoreText.GetComponent<TextMeshProUGUI>().text = newScore.ToString();

    }
    private void MoveCam()
    {
        
        cam.transform.position = Vector3.SmoothDamp(startPos, targetPos, ref velocity, smoothTime);


    }
    private void spawnPlatfrom()
    {
        var prefabIndex = Random.Range(0, prefabs.Length);
        var positionX = Random.Range(2, 4.5f);
        var position = new Vector3(positionX, this.gameObject.transform.position.y + platformGap, prefabs[prefabIndex].transform.position.z);

        Instantiate(prefabs[prefabIndex], position, prefabs[prefabIndex].transform.rotation);
    }

    IEnumerator startCrumbling()
    {
        yield return new WaitForSeconds(0.5f);
        leftChildSpriteRenderer.sprite = leftDamagedSprite;
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);


        //play the last crumbling animation with particles by using instantiate method
        //and then destroy the gameObject all together


    }

}
