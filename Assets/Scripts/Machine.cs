using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{

    private float time = 0;
    public string WorkingName, WorkingViewName;
    protected Collider ambool;
    public static bool Vortexon;
    public Text Timee, TriggerStayTime;
    public Animator Open;


    private void OnTriggerStay(Collider other)
    {

        if (time >= 2.0f)
        {
            TriggerStayTime.text = ((int)time).ToString();
            if (other.tag == "Centerfugtunes" && 
                other.GetComponent<CenterfugtunesControl>().Inside.Count > 0)
            {
                ambool = other;
                ChangeCameraView(WorkingViewName,"Base", WorkingName);
            }
            
        }
        else
            time += Time.deltaTime;
    }



    //Camera Animation
    public void ChangeCameraView(string Dissable1, string Dissable2, string Enable)
    {
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool(Dissable1, false);
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool(Enable, false);
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool(Dissable2, true);
    }
    


    public void Votrex()
    {
        Vortexon = !Vortexon;
        gameObject.GetComponent<Animator>().SetBool("IsWorking", Vortexon);
    }




    public void StartCorontine()
    {
        ChangeCameraView("base", WorkingName, WorkingViewName);
        TurnOn();
        StartCoroutine(SatrtWorking());

    }


    public IEnumerator SatrtWorking()
    {
        while (ChangeValue.MVal > 0)
        {
            yield return new WaitForSeconds(1);
            ChangeValue.MVal--;
            Timee.text = ChangeValue.MVal.ToString();
        }
        ChangeCameraView(WorkingName, WorkingViewName, "Base");
        ChangeValue.RVal = 0;
        //Temp.text = ChangeValue.RVal.ToString();
        TurnOff();
        ambool.GetComponent<CenterfugtunesControl>().ThermoDone = true;
    }


    public void TurnOff()
    {
        Open.SetBool("IsWorking", false);
    }
    public void TurnOn()
    {
        Open.SetBool("IsWorking", true);
    }


    private void OnTriggerExit(Collider other)
    {
        time = 0;
    }
}
