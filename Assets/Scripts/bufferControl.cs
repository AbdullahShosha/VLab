using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bufferControl : MonoBehaviour
{
   
    public string Name ;
    static bool IsOpen;
    public GameObject buf;
    public Text bufName;




    public void OpenCloseBuffer()
    {
        IsOpen = !IsOpen;
        if (IsOpen)
            buf.SetActive(false);
        else buf.SetActive(true);
    }

    void OnMouseOver()
    {
        bufName.text = Name;
    }
}
