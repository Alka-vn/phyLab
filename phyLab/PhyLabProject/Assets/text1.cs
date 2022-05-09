using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text1 : MonoBehaviour
{
   List<string> firstChoice = new List<string>() {"V=RI ","Resistance","10m/s²","It is a vector quantity","1mm ","1mm","Ohm","1/f = (n — 1)(1/r1 – 1/r2)","watts","45 degree"};


    void Start()
    {
        //GetComponent<TextMesh>().text = firstChoice[0];
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
             GetComponent<TextMesh>().text = firstChoice[textControl.randQuestion];
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
