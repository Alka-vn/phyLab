using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rheostatControl : MonoBehaviour
{
   public string detail = "This is a instrument";
    public Transform descriptionObj;
    public Transform instrument;
    public Transform PositionObj;
    private Vector3 originalSize,originalPosition; 
    public Quaternion originalRotation;
    public Vector3 newPosition, newSize, descriptionPosition;
    private bool isRotate=false;
    void Start()
    {
        descriptionObj.GetComponent<TextMesh>().text="";
    }

    // Update is called once per frame
    void Update()
    {
         if(isRotate)
        {
        instrument.transform.Rotate(new Vector3(0, 1, 0), Space.Self);
        }
    }
    public void onSelection()
    {
        if(instrumentControl.selected=="")
        {
            originalPosition=instrument.transform.position;
            originalSize=instrument.transform.localScale;
            originalRotation=instrument.transform.rotation;
            //newPosition= new Vector3(-0.25f,3.0f,1.0f);
            //newSize= originalSize;
            instrument.transform.position=PositionObj.position;
            //instrument.transform.localScale=newSize;
            isRotate=true;
            //descriptionObj.transform.position=new Vector3(0.0f,3.0f,1.0f);
            instrumentControl.selected=gameObject.name;
            Debug.Log(instrumentControl.selected);
            detail="an electrical instrument used to control a current by varying the resistance or  a rheostat is a variable resistor which is used to control current. Rheostat, adjustable resistor used in applications that require the adjustment of current or the varying of resistance in an electric circuit. The rheostat can adjust generator characteristics, dim lights, and start or control the speed of motors.";
            descriptionObj.GetComponent<TextMesh>().text=instrumentControl.SpliceText(detail,25);
        }
        else if(instrumentControl.selected == gameObject.name)
        {
            instrument.transform.position=originalPosition;
            instrument.transform.localScale=originalSize;
            instrument.transform.rotation=originalRotation;
            descriptionObj.GetComponent<TextMesh>().text="";
            isRotate=false;
            instrumentControl.selected="";
        }
    }
    
}
