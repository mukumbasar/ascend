using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    public GameObject[] rightsidePrefabs;
    public GameObject[] leftsidePrefabs;

    private float positionX1;

    private bool spawned = false;  
    private void Awake()
    {

        positionX1 = Random.Range(-5.5f, 5.5f);
        
        CreateTheFirstPlatform();

    }

    private void CreateTheFirstPlatform()
    {
       

        if(positionX1 >= 0)
        {
            var prefabIndex1 = Random.Range(0, rightsidePrefabs.Length);
            var position1 = new Vector3(positionX1, 2.73f, rightsidePrefabs[prefabIndex1].transform.position.z);

            Instantiate(rightsidePrefabs[prefabIndex1], position1, rightsidePrefabs[prefabIndex1].transform.rotation);

            spawned = true;
        }
        else if(positionX1 < 0)
        {
            var prefabIndex1 = Random.Range(0, leftsidePrefabs.Length);
            var position1 = new Vector3(positionX1, 2.73f, leftsidePrefabs[prefabIndex1].transform.position.z);

            Instantiate(leftsidePrefabs[prefabIndex1], position1, leftsidePrefabs[prefabIndex1].transform.rotation);

            spawned = true;
        }
        
    }

    private void Update()
    {
        if (positionX1 > 0 && spawned == true)
        {
            var prefabIndex2 = Random.Range(0, leftsidePrefabs.Length);
            var positionX2 = Random.Range(-5.5f, 0);
            var position2 = new Vector3(positionX2, 11.1f, leftsidePrefabs[prefabIndex2].transform.position.z);

            Instantiate(leftsidePrefabs[prefabIndex2], position2, leftsidePrefabs[prefabIndex2].transform.rotation);

            spawned = false;
        }
        else if (positionX1 < 0 && spawned == true)
        {
            var prefabIndex2 = Random.Range(0, rightsidePrefabs.Length);
            var positionX2 = Random.Range(0, 5.55f);
            var position2 = new Vector3(positionX2, 11.1f, rightsidePrefabs[prefabIndex2].transform.position.z);

            Instantiate(rightsidePrefabs[prefabIndex2], position2, rightsidePrefabs[prefabIndex2].transform.rotation);

            spawned = false;
        }
    }
}
