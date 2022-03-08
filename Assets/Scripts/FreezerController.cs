using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezerController : MonoBehaviour
{

    public static int Temp;
    public Text Field, ErrorPanelText;
    public GameObject Panel,DonePanel;

    public void Set()
    {
        Temp = int.Parse(Field.text);
        if (Temp == 20)
        {
            Field.text = "";
            DonePanel.SetActive(true);
        }
        else
        {
            ErrorPanelText.text = "the temperature must be 20 degrees";
            Steps.WrongStepPanel.SetActive(true); 
        }
        Panel.SetActive(false);
    }
    public void ONPanel()
    {
        if (Steps.Step == 14)
            Panel.SetActive(true);
        else
        {
            ErrorPanelText.text = "Wrong Step";
            Steps.WrongStepPanel.SetActive(true); 
        }

    }
}
