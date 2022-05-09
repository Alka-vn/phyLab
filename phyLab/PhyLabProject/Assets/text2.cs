using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text2 : MonoBehaviour
{
    List<string> secondChoice = new List<string>() {"R=VI","Voltage","9.8m/s²","It is not a vector quantity","0 .5mm","0.01mm","Hertz","f = (n — 1)(1/r1 – 1/r2)","Decibel","0 degree"};

    void Start()
    {
        //GetComponent<TextMesh>().text = secondChoice[0];
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
             GetComponent<TextMesh>().text = secondChoice[textControl.randQuestion];
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
