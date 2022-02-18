using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragDrop : MonoBehaviour
{
    public GameObject campos;
    private Vector3 mOffset;
    private float mZCoorrd;
    public Vector3 startPos, mousePos, worldPosition;
    
    //private bool IsDraging;


    private void Start()
    {
        startPos = transform.position;
    }

    

    private void OnMouseUp()
    {
        //IsDraging = false;
        transform.position = startPos;
    }

    private void OnMouseDown()
    {
        //IsDraging = true;
        Debug.Log("OnMouseDown");
        
        //mZCoorrd = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //mOffset = gameObject.transform.position - GetMouseWorldPos();
        
    }

    /*private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoorrd;
        return Camera.main.WorldToScreenPoint(mousePoint);
    }*/
    private void OnMouseDrag()
    {
        /*Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldPosition;*/
        mousePos = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos) - campos.transform.position;
        transform.position = worldPosition;
        Debug.Log("OnMouseDrag");
        /*transform.position = GetMouseWorldPos() + mOffset;*/
    }
}
