using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPos : MonoBehaviour
{

    public Transform[] BasePos;
    int iterate = 0;



    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            iterate = 0;
            Move(iterate);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            iterate = 1;
            Move(iterate);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            iterate = 3;
            Move(iterate);
        }
    }
    public void Move(int x)
    {
        gameObject.transform.position = BasePos[iterate].position;
        gameObject.transform.rotation = BasePos[iterate].rotation;
    }
    
   
}
