using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterfugtunesControl : MonoBehaviour
{
    public IDictionary<string, int> Inside = new Dictionary<string, int>();
    public int NumberOfElements = 0;

    public bool CenterDone = false,ThermoDone = false,FreezingDone = false , Votrex = false;
    public float time = 0;
    public Text Ttext;
    public Transform Ready;
    


    private void OnTriggerStay(Collider other)
    {
        Ttext.text = ((int)time).ToString();
        if (time >= 2.0f)
        {

            if (other.CompareTag("pipepitte") &&
                other.GetComponent<PipepitteController>().InsidePip != "empty")
            {
                if (Inside.ContainsKey(other.GetComponent<PipepitteController>().InsidePip))
                    Inside[other.GetComponent<PipepitteController>().InsidePip] += other.GetComponent<PipepitteController>().Size;
                else
                {
                    Inside.Add(other.GetComponent<PipepitteController>().InsidePip, other.GetComponent<PipepitteController>().Size);
                    NumberOfElements++;
                }

                other.GetComponent<PipepitteController>().InsidePip = "empty";
            }

            
        }
        else time += Time.deltaTime;
    }
    private void OnTriggerExit(Collider other)
    {
        time = 0;
    }
}