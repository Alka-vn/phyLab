using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!textControl.play)
        {
            GetComponent<TextMesh>().text="";
        }
        else
        {
            GetComponent<TextMesh>().text="Next";
        }
    }

    public void onSelection()
    {
        textControl.randQuestion=-1;
        //textControl.counter++;
    }

}
