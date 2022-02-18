using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterControl : Machine
{
    public Text Timee, Rev;
    public Animator Open;

   

    public void StartCorontine()
    {
        StartWorking();
        TurnOn();
        StartCoroutine(CenterVPos());
        
    }

    
    public IEnumerator CenterVPos()
    {
        while (ChangeValue.MVal > 0)
        {
            yield return new WaitForSeconds(1);
            ChangeValue.MVal--;
            Timee.text = ChangeValue.MVal.ToString();
        }
        Reset();
        ChangeValue.RVal = 0;
        Rev.text = ChangeValue.RVal.ToString();
        TurnOff();
        ambool.GetComponent<CenterfugtunesControl>().CenterDone = true;
    }

    
    public void TurnOff()
    {
        Open.SetBool("IsWorking", false);
    }
    public void TurnOn()
    {
        Open.SetBool("IsWorking", true);
    }
    

}
