using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    public GameObject[] rightsidePrefabs;
    public GameObject[] leftsidePrefabs;

    private float positionX1;
    private float twoSidedDice;

    private bool spawned = false;  
    private void Awake()
    {

        twoSidedDice = Random.Range(-1, 1);
        
        CreateTheFirstPlatform();

    }

    private void CreateTheFirstPlatform()
    {
       

        if(twoSidedDice >= 0)
        {
            positionX1 = Random.Range(2, 5.5f);
            var prefabIndex1 = Random.Range(0, rightsidePrefabs.Length);
            var position1 = new Vector3(positionX1, 0.73f, rightsidePrefabs[prefabIndex1].transform.position.z);

            Instantiate(rightsidePrefabs[prefabIndex1], position1, rightsidePrefabs[prefabIndex1].transform.rotation);

            spawned = true;
        }
        else if(twoSidedDice < 0)
        {
            positionX1 = Random.Range(-5.5f, -2f);
            var prefabIndex1 = Random.Range(0, leftsidePrefabs.Length);
            var position1 = new Vector3(positionX1, 0.73f, leftsidePrefabs[prefabIndex1].transform.position.z);

            Instantiate(leftsidePrefabs[prefabIndex1], position1, leftsidePrefabs[prefabIndex1].transform.rotation);

            spawned = true;
        }
        
    }

    private void Update()
    {
        if (twoSidedDice >= 0 && spawned == true)
        {
            var prefabIndex2 = Random.Range(0, leftsidePrefabs.Length);
            var positionX2 = Random.Range(-5.5f, -2);
            var position2 = new Vector3(positionX2, 5.55f, leftsidePrefabs[prefabIndex2].transform.position.z);

            Instantiate(leftsidePrefabs[prefabIndex2], position2, leftsidePrefabs[prefabIndex2].transform.rotation);

            spawned = false;
        }
        else if (twoSidedDice < 0 && spawned == true)
        {
            var prefabIndex2 = Random.Range(0, rightsidePrefabs.Length);
            var positionX2 = Random.Range(2, 5.55f);
            var position2 = new Vector3(positionX2, 5.55f, rightsidePrefabs[prefabIndex2].transform.position.z);

            Instantiate(rightsidePrefabs[prefabIndex2], position2, rightsidePrefabs[prefabIndex2].transform.rotation);

            spawned = false;
        }
    }
}
