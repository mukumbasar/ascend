using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnvironment : MonoBehaviour
{
    private Vector3 currentPos;
    private Vector3 firstBorder;

    //for the first wall push
    private bool firstWallPush;
   

    //for the second wall push
    private bool secondWallPush;
    

    public GameObject wallsTwo;
    public GameObject wallsOne;

    private void Awake()
    {
        // for the first wall push
        
        firstBorder = new Vector3(currentPos.x, currentPos.y + 7f, currentPos.z);
  
        firstWallPush = true;

    }

    private void Update()
    {
        currentPos = this.gameObject.transform.position;
        var dist = Vector3.Distance(firstBorder, currentPos);
        Debug.Log("ye" + dist);

        //if (firstWallPush && Vector3.Distance(new Vector3(currentPos.x,currentPos.y + 8.79f,currentPos.z), currentPos) <= 0.1f)
        //{
        //    var wallsTwoPos = wallsTwo.transform.position;
        //    wallsTwo.transform.position = new Vector3(wallsTwoPos.x, wallsTwoPos.y + 44f, wallsTwoPos.z);
        //    firstWallPush = false;
        //    secondWallPush = true;
        //}
        //    if (secondWallPush && distSecond <= 0.1f)
        //    {
        //        currentPos = this.gameObject.transform.position;
        //        var secondDistPoint = new Vector3(currentPos.x, currentPos.y + 22f, currentPos.z);
        //        distSecond = Vector3.Distance(secondDistPoint, currentPos);
        //    }
        //
    }
}
