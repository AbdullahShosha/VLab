using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PipepitteController : MonoBehaviour
{
    public int Size;
    public string InsidePip;
    public GameObject Panel;
    public InputField Field;
    public Text Ttext;
    public float time = 0;

    //public static bool[] buffers = new bool[3];

    // Start is called before the first frame update
    /*void Start()
    {
        for (int i = 0; i < 3; i++)
            buffers[i] = false;
    }
*/
    // Update is called once per frame
    private void Start()
    {
        InsidePip  = "empty";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ONPanel();
        }
    }
    public void ONPanel()
    { 
        Panel.SetActive(true);
    }
    public void Set()
    {
        Size = int.Parse(Field.text);
        Field.Select();
        Field.text = "";
        Panel.SetActive(false);
        
    }

    private void OnTriggerStay(Collider other)
    {
        Ttext.text = ((int)time).ToString();
        if (time >= 1.0f)
        {
            if (InsidePip == "empty" && other.tag == "Buffer")
            {
                InsidePip =  other.gameObject.GetComponent<bufferControl>().Name;
            }
        }
        else
            time += Time.deltaTime;

    }
    private void OnTriggerExit(Collider other)
    {
        time = 0;
    }
}
