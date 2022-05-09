using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellControl : MonoBehaviour
{
    public string detail = "This is a instrument";
    public Transform descriptionObj;
    public Transform instrument;
    public Transform PositionObj;
    private Vector3 originalSize,originalPosition; 
    public Quaternion originalRotation;
    private bool isRotate=false;
    void Start()
    {
        descriptionObj.GetComponent<TextMesh>().text="";
    }

    void Update()
    {
         if(isRotate)
        {
        instrument.transform.Rotate(new Vector3(1, 0, 0), Space.Self);
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
            instrument.transform.localScale=originalSize*3;
            isRotate=true;
            //descriptionObj.transform.position=new Vector3(0.0f,3.0f,1.0f);
            instrumentControl.selected=gameObject.name;
            Debug.Log(instrumentControl.selected);
            detail="A cell is a single electrical energy source which uses chemical reactions to produce a current. An electrical cell is an 'electrical power supply'. It converts stored chemical energy into electrical potential energy. One or more cells together are called battery";
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
