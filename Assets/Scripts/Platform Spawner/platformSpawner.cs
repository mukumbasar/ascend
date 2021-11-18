using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    public GameObject[] prefabs;

    private float positionX1;

    private bool spawned = false;  
    private void Awake()
    {
        var prefabIndex1 = Random.Range(0, prefabs.Length);
        positionX1 = Random.Range(-5.5f, 5.55f);
        var position1 = new Vector3(positionX1, 2.73f, prefabs[prefabIndex1].transform.position.z);

        Instantiate(prefabs[prefabIndex1], position1, prefabs[prefabIndex1].transform.rotation);

        spawned = true;

       

    }

    private void Update()
    {
        if (positionX1 > 0 && spawned == true)
        {
            var prefabIndex2 = Random.Range(0, prefabs.Length);
            var positionX2 = Random.Range(-5.5f, 0);
            var position2 = new Vector3(positionX2, 11.1f, prefabs[prefabIndex2].transform.position.z);

            Instantiate(prefabs[prefabIndex2], position2, prefabs[prefabIndex2].transform.rotation);

            spawned = false;
        }
        else if (positionX1 < 0 && spawned == true)
        {
            var prefabIndex2 = Random.Range(0, prefabs.Length);
            var positionX2 = Random.Range(0, 5.55f);
            var position2 = new Vector3(positionX2, 11.1f, prefabs[prefabIndex2].transform.position.z);

            Instantiate(prefabs[prefabIndex2], position2, prefabs[prefabIndex2].transform.rotation);

            spawned = false;
        }
    }
}
