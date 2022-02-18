using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BufferName : MonoBehaviour
{
    public static string Bname;
    public static int Order = 3;
    //public Text BuffNameTXT;

    string[] names = new string[4];
    // Start is called before the first frame update
    void Start()
    {
        names[0] = "Wash Buffer1";
        names[1] = "Wash Buffer2";
        names[2] = "Elution Buffer";
        names[3] = "None";
    }

    // Update is called once per frame
    void Update()
    {
        BuffNameChange();
    }
    public void BuffNameChange()
    {
        Bname = names[Order];
        GetComponent<Text>().text = Bname;
    }
}
