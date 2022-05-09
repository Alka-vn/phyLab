using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text4 : MonoBehaviour
{
    List<string> forthChoice = new List<string>() {"V =TI","Pressure","6.8m/s²","It can't be vector or scalar","0.001mm","0.001mm","Voltage","1/f = (n — 1)(r2– r2)","Dioptre","90 degree"};

    void Start()
    {
        //GetComponent<TextMesh>().text = forthChoice[0];
    }
    // Update is called once per frame
    void Update()
    {
        if(!textControl.play)
        {
            GetComponent<TextMesh>().text="";
        }
        else if(textControl.randQuestion>-1)
        {
             GetComponent<TextMesh>().text = forthChoice[textControl.randQuestion];
        }
    }

    public void onSelection()
    {
        if(!textControl.choiceSelected)
        {
            textControl.selectedAnswer=gameObject.name;
            textControl.choiceSelected=true;
        }
    }
}
