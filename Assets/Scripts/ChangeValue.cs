using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeValue : MonoBehaviour
{
    public Text TVal,SVal;
    public static int MVal, RVal ;
    public int IncreaseBy;


    private void Start()
    {
        ResetValues();
    }
    public void SetMinValue(int Value)
    {
        
        //transform.Rotate(0.0f,0.0f, 20.0f,Space.Self );
        MVal += Value;
        TVal.text = MVal.ToString();
    }
    public void SetRevolValue(int Value)
    {
        //transform.Rotate(0.0f, 0.0f, 20.0f, Space.Self);
        //transform.Rotate(0, 0, 20 * Time.deltaTime, Space.World);
        RVal += Value;
        SVal.text = RVal.ToString();
    }
    public void ResetValues()
    {
        MVal = 0; RVal = 0;
        TVal.text = MVal.ToString();
        SVal.text = RVal.ToString();
        
    }
}
