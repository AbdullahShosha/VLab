using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezerController : MonoBehaviour
{

    public static int Temp;
    public Text Field;
    public GameObject Panel;

    public void Set()
    {
        Temp = int.Parse(Field.text);
        Field.text = "";
        Panel.SetActive(false);
        
    }
    public void ONPanel()
    {
        Panel.SetActive(true);
    }
}
