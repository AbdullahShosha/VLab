using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{

    private float time = 0;
    public static string WorkingName, WorkingViewName;
    protected Collider ambool;
    public Text Ttext;
    public static bool Vortexon;

    
    private void OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponent<CenterControl>())
        {
            WorkingName = "Center";
            WorkingViewName = "ViewCenter";
        }
        else if (gameObject.GetComponent<ThermoControl>())
        {
            WorkingName = "Thermo";
            WorkingViewName = "ViewThermo";
        }

        if (time >= 2.0f)
        {
            Ttext.text = ((int)time).ToString();
            if (other.tag == "Centerfugtunes" && 
                other.GetComponent<CenterfugtunesControl>().Inside.Count > 0)
            {
                ambool = other;
                ChangeView();
            }
            
        }
        else
            time += Time.deltaTime;
    }



    public void ChangeView()
    {
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool(WorkingViewName, false);
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool("Base", false);
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool(WorkingName, true);
    }
    public void StartWorking()
    {
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool("Base", false);
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool(WorkingName, false);
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool(WorkingViewName, true);
    }
    public void Reset()
    {
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool(WorkingName, false);
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool(WorkingViewName, false);
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool("Base", true);
    }
    public void Votrex()
    {
        Vortexon = !Vortexon;
        gameObject.GetComponent<Animator>().SetBool("IsWorking", Vortexon);
    }
    private void OnTriggerExit(Collider other)
    {
        time = 0;
    }
}
