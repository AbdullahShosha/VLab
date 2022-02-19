using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{

    private float time = 0;
    public string WorkingName, WorkingViewName;
    protected Collider ambool;
    
    public Text MachineScreenTime, TriggerStayTime;
    public Animator Work;


    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.GetComponent<CenterfugtunesControl>().NumberOfElements);
        if (time >= 2.0f)
        {
            TriggerStayTime.text = ((int)time).ToString();
            if (other.CompareTag("Centerfugtunes") && 
                other.GetComponent<CenterfugtunesControl>().NumberOfElements > 0)
            {  
                ambool = other;
                ResetCameraValues();
                GameObject.Find("mainCamera").GetComponent<Animator>().SetBool(WorkingName, true);
            }
        }
        else
            time += Time.deltaTime;
    }



    //Camera Animation
    public void ResetCameraValues()
    {
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool(WorkingName, false);
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool(WorkingViewName, false);
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool("Base", false);
    }
    

    public void Startcorontine()
    {
        ResetCameraValues();
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool(WorkingViewName, true);
        TurnOn();
        StartCoroutine(SatrtWorking());

    }


    public IEnumerator SatrtWorking()
    {
        while (ChangeValue.MVal > 0)
        {
            yield return new WaitForSeconds(1);
            ChangeValue.MVal--;
            MachineScreenTime.text = ChangeValue.MVal.ToString();
        }
        
        ResetCameraValues();
        GameObject.Find("mainCamera").GetComponent<Animator>().SetBool("Base", true);
        ChangeValue.RVal = 0;
        //Temp.text = ChangeValue.RVal.ToString();
        ambool.GetComponent<CenterfugtunesControl>().ThermoDone = true;
        TurnOff();

    }


    public void TurnOff()
    {
        Work.SetBool("IsWorking", false);
        
    }
    public void TurnOn()
    {
        Work.SetBool("IsWorking", true);
    }


    private void OnTriggerExit(Collider other)
    {
        time = 0;
    }
}
