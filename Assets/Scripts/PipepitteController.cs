using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PipepitteController : MonoBehaviour
{
    public int Size = 0 ;
    public string InsidePip;
    public GameObject Panel;
    public InputField Field;
    public Text Ttext;
    public float time = 0;
    public Transform Reset;

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
        Reset.position = gameObject.transform.position;
        InsidePip  = "empty";
    }

    public void ONPanel()
    {
        Size = 0;
        Panel.SetActive(true);
    }
    public void Set()
    {
        Size = int.Parse(Field.text);
        Field.Select();
        Field.text = "";
        Panel.SetActive(false);
        Steps.instructiontext.text = "add it to the sample";
    }

    private void OnTriggerStay(Collider other)
    {
        Ttext.text = ((int)time).ToString();
        if (time >= 2.0f)
        {
            if ( other.CompareTag("Buffer"))
            {
                if (((Steps.Step == 1 && other.gameObject.GetComponent<bufferControl>().Name == "Blood") ||
                (Steps.Step == 2 && other.gameObject.GetComponent<bufferControl>().Name == "KProtein") ||
                (Steps.Step == 3 && other.gameObject.GetComponent<bufferControl>().Name == "LysisSolution") ||
                (Steps.Step == 6 && other.gameObject.GetComponent<bufferControl>().Name == "Ithanol") ||
                (Steps.Step == 8 && other.gameObject.GetComponent<bufferControl>().Name == "WashBuffer1") ||
                (Steps.Step == 10 && other.gameObject.GetComponent<bufferControl>().Name == "ElutionBuffer") ||
                (Steps.Step == 12 && other.gameObject.GetComponent<bufferControl>().Name == "WashBuffer2")))
                {
                    InsidePip = other.gameObject.GetComponent<bufferControl>().Name;
                    if (Size == 0)
                    ONPanel();
                    

                }
                else
                    Steps.WrongStepPanel.SetActive(true);

                transform.position = Reset.position;
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
