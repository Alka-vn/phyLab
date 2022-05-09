using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meterbridgeControl : MonoBehaviour
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
         /* if(isRotate)
        {
        instrument.Rotate(0,1,0);
        } */
    }
    public void onSelection()
    {
        if(instrumentControl.selected=="")
        {
            originalPosition=instrument.transform.position;
            originalSize=instrument.transform.localScale;
            originalRotation=instrument.transform.rotation;
            //newPosition= new Vector3(-0.25f,3.0f,1.0f);
            newSize= originalSize/2;
            instrument.transform.position=PositionObj.transform.position;
            instrument.transform.rotation=Quaternion.Euler(-90.0f,0.0f,0.0f);
            instrument.transform.localScale=newSize;
            //isRotate=true;
            //descriptionObj.transform.position=new Vector3(0.0f,3.0f,1.0f);
            instrumentControl.selected=gameObject.name;
            Debug.Log(instrumentControl.selected);
            detail="A meter bridge also called a slide wire bridge is an instrument that works on the principle of a Wheatstone bridge. A meter bridge is used in finding the unknown resistance of a conductor as that of in a Wheatstone bridge. A meter bridge consists of a wire of length 1 m and of uniform cross-sectional area stretched taut and clamped between two thick metallic strips bent at right angles with two gaps across which resistors are to be connected.";
            descriptionObj.GetComponent<TextMesh>().text= instrumentControl.SpliceText(detail,25);
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
