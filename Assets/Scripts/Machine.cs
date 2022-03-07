using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{
    private bool GoToCenter;
    private float time = 0;
    public string WorkingName, WorkingViewName;
    protected Collider ambool;
    public GameObject DonePanel;
    public Text MachineScreenTime, TriggerStayTime ,ErrorPanelText;
    public Animator Work;

    private void OnTriggerEnter(Collider other)
    {
        GoToCenter = true;
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.GetComponent<CenterfugtunesControl>().NumberOfElements);
        if (time >= 2.0f)
        {
            TriggerStayTime.text = ((int)time).ToString();
            if (other.CompareTag("Centerfugtunes"))
            {
                if(other.GetComponent<CenterfugtunesControl>().NumberOfElements > 0)
                {
                    ambool = other;
                    ResetCameraValues();
                    if (GoToCenter)
                    { 
                        if ((WorkingName == "Thermo" && Steps.Step == 5) ||
                        (WorkingName == "Center" &&
                        (Steps.Step == 7 || Steps.Step == 9 || Steps.Step == 11 || Steps.Step == 13)))
                        {
                            GameObject.Find("mainCamera").GetComponent<Animator>().SetBool(WorkingName, true);
                            GoToCenter = false;
                        }
                        else
                        {
                            ErrorPanelText.text = "Wrong Step";
                            Steps.WrongStepPanel.SetActive(true);
                            other.GetComponent<CenterfugtunesControl>().ThermoDone = true;
                        }
                    }
                    
                }
                else
                {
                    other.GetComponent<CenterfugtunesControl>().ThermoDone = true;
                    Steps.WrongStepPanel.SetActive(true);
                    ErrorPanelText.text = "Empty Sample";
                }
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
        if (Steps.Step < 13)
            Steps.NextStep();
        else DonePanel.SetActive(true);
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
