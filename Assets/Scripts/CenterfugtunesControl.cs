using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterfugtunesControl : MonoBehaviour
{
    public IDictionary<string, int> Inside = new Dictionary<string, int>();
    public int NumberOfElements = 0;
    public Sprite NextStepHelper, WrongStephelper;
    public Image helper;
    public bool CenterDone = false,ThermoDone = false,FreezingDone = false , VotrexDone = false;
    public float time = 0;
    public Text Ttext;
    public Transform Ready;

    //public delegate void test();

    private void Update()
    {
        //test a = Update;
        //a();
        
        if (CenterDone || ThermoDone || FreezingDone || VotrexDone)
        {
            gameObject.transform.position = Ready.position;
            CenterDone = false; ThermoDone = false; FreezingDone = false; VotrexDone = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Ttext.text = ((int)time).ToString();
        if (time >= 2.0f)
        {

            if (other.CompareTag("pipepitte") &&
                other.GetComponent<PipepitteController>().InsidePip != "empty")
            {

                if ((Steps.Step == 1 && other.GetComponent<PipepitteController>().InsidePip == "Blood" && other.GetComponent<PipepitteController>().Size == 200) ||
                    (Steps.Step == 2 && other.GetComponent<PipepitteController>().InsidePip == "KProtein" && other.GetComponent<PipepitteController>().Size == 20) ||
                    (Steps.Step == 3 && other.GetComponent<PipepitteController>().InsidePip == "LysisSolution" && other.GetComponent<PipepitteController>().Size == 400) ||
                    (Steps.Step == 6 && other.GetComponent<PipepitteController>().InsidePip == "Ithanol" && other.GetComponent<PipepitteController>().Size == 200) ||
                    (Steps.Step == 8 && other.GetComponent<PipepitteController>().InsidePip == "WashBuffer1" && other.GetComponent<PipepitteController>().Size == 500) ||
                    (Steps.Step == 10 && other.GetComponent<PipepitteController>().InsidePip == "ElutionBuffer" && other.GetComponent<PipepitteController>().Size == 200) ||
                    (Steps.Step == 12 && other.GetComponent<PipepitteController>().InsidePip == "WashBuffer2" && other.GetComponent<PipepitteController>().Size == 500))
                {
                    if (Inside.ContainsKey(other.GetComponent<PipepitteController>().InsidePip))
                        Inside[other.GetComponent<PipepitteController>().InsidePip] += other.GetComponent<PipepitteController>().Size;
                    else
                    {
                        Inside.Add(other.GetComponent<PipepitteController>().InsidePip, other.GetComponent<PipepitteController>().Size);

                        NumberOfElements++;
                    }
                    other.transform.GetChild(0).GetComponent<Animator>().SetBool("Soaking", false);
                    helper.sprite = NextStepHelper;
                    Steps.NextStep();
                    other.transform.position = other.GetComponent<PipepitteController>().Reset.position;
                }
                other.GetComponent<PipepitteController>().InsidePip = "empty";
                other.GetComponent<PipepitteController>().Size = 0;
            }
            if (Steps.Step == 4)
            {
                if (other.CompareTag("Votrex"))
                { 
                    Steps.NextStep();
                    VotrexDone = true;
                }
                else
                {
                    Steps.WrongStepPanel.SetActive(false);
                    VotrexDone = true;
                }
            }

        }
        else
        {
            if(other.CompareTag("pipepitte"))
                other.transform.GetChild(0).GetComponent<Animator>().SetBool("Soaking", true);
            time += Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        time = 0;
    }
}