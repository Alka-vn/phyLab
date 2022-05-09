using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text3 : MonoBehaviour
{
     List<string> thirdChoice = new List<string>() {"I=VR","Temperatures","8.9m/s²","It may be a scalar","0.1mm","0.5mm","Watts","1/f = (n + 1)(1/r1 + 1/r2)","Intensity","30 degree"};

    void Start()
    {
        //GetComponent<TextMesh>().text = thirdChoice[0];
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
             GetComponent<TextMesh>().text = thirdChoice[textControl.randQuestion];
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
