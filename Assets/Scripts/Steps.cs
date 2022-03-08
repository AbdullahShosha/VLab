using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Steps : MonoBehaviour
{
    public static Text steptext, instructiontext;
    public static GameObject WrongStepPanel;
    public GameObject WrongStepPanel1;
    static string[] instructions = new string[14];
    public static int Step = 1;
    // Start is called before the first frame update
    void Start()
    {
        instructions[0] = "take 200 Microliters of blood form the buffer ";
        instructions[1] = "take 20 Microliters of k.protein from the buffer";
        instructions[2] = "take 400 Microliters from Lysis Solution buffer";
        instructions[3] = "put the sample in the Votrex for 1m";
        instructions[4] = "place the sample in the thermomixer for 10m";
        instructions[5] = "take 200 Microliters of Ithanol 96-100 from the buffer";
        instructions[6] = "place the sample in the centerifuge and set it to 6000 cycles per minute for 1m ";
        instructions[7] = "take 500 Microliters from Wash buffer1 ";
        instructions[8] = "place the sample in the centerifuge and set it to 14000 cycles per minute for 3m";
        instructions[9] = "take 200 Microliters from Elution buffer";
        instructions[10] = "place the sample in the centerifuge and set it to 8000 cycles per minute for 3m";
        instructions[11] = "take 500 Microliters from Wash buffer2";
        instructions[12] = "place the sample in the centerifuge and set it to 14000 cycles per minute for 3m";
        instructions[13] = "put the sample in the freezer at a teperature of 20 degrees";
        steptext = GameObject.FindGameObjectWithTag("Step").GetComponent<Text>();
        instructiontext = GameObject.FindGameObjectWithTag("StepText").GetComponent<Text>();
        WrongStepPanel = WrongStepPanel1;

        steptext.text = "Step " + (Step).ToString() + " :";
        instructiontext.text = instructions[Step-1];
 
    }


    public static void NextStep()
    {
        Step++;
        steptext.text = "Step "+Step.ToString()+" :";
        instructiontext.text = instructions[Step-1];
        
    }
    public void okWrongStep()
    {
        WrongStepPanel.SetActive(false);
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
    public void ChangeScene(int indx)
    {
        SceneManager.LoadScene(indx);
    }
}
