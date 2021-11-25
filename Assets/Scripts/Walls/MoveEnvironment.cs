using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnvironment : MonoBehaviour
{
    private Vector3 currentPos;
    

    //for the first wall push
    private bool firstWallPush;
    private float dist1;
    private Vector2 firstBorder;


    //for the second wall push
    private bool secondWallPush;
    private float dist2;
    private Vector2 secondBorder;

    

    public GameObject wallsTwo;
    public GameObject wallsOne;

    private void Awake()
    {
        // for the first wall push

        
        
        firstBorder = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 8.8f);
  
        firstWallPush = true;

    }

    private void Update()
    {
        if(firstWallPush)
        {
            currentPos = this.gameObject.transform.position;

            dist1 = Vector2.Distance(firstBorder, currentPos);

            Debug.Log(+dist1);

            if (dist1 <= 0.1f)
            {
                wallsTwo.transform.position = new Vector2(wallsTwo.transform.position.x, wallsTwo.transform.position.y + 50);
                firstWallPush = false;

                secondWallPush = true;
                secondBorder = new Vector2(firstBorder.x, firstBorder.y + 22);
                

            }
        }

        if(secondWallPush)
        {
            currentPos = this.gameObject.transform.position;
            dist2 = Vector2.Distance(secondBorder, currentPos);
            Debug.Log(dist2);
            if (dist2 <= 0.1f)
            {
                wallsOne.transform.position = new Vector2(wallsOne.transform.position.x, wallsOne.transform.position.y + 50);
                firstWallPush = true;

                secondWallPush = false;
                firstBorder = new Vector2(secondBorder.x, secondBorder.y + 22);
            }
        }
        

        
    }
}
