using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plugKey : MonoBehaviour
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
            //newPosition= new Vector3(0f,3.0f,1.0f);
            newSize= originalSize*3;
            instrument.transform.position=PositionObj.transform.position;
            instrument.transform.localScale=newSize;
            //descriptionObj.transform.position=new Vector3(0.0f,3.0f,1.0f);
            isRotate=true;
            instrumentControl.selected=gameObject.name;
            Debug.Log(instrumentControl.selected);
            switch (gameObject.name)
            {
                case "plug key":
                    detail="A plug key is an electrical component which acts like a switch. A small metallic key is provided which is inserted in a metallic base to switch on the circuit and if it is taken off from its base then the circuit get switched off. When plug key is open, no current flows through the circuit and when plug key is closed, current flows through the circuit.";
                    break;
                case "ConcaveLens":
                    detail = "A concave lens is a lens that possesses at least one surface that curves inwards. It is a diverging lens, meaning that it spreads out light rays that have been refracted through it. A concave lens is thinner at it diverges a straight light beam coming from the source to a diminished, upright, virtual image is known as a concave lens. It can form both real and virtual images.";
                    break;
                default:
                    detail="unspecified instrument.";
                    break;
            }
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