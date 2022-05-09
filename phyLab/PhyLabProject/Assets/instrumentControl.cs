using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instrumentControl : MonoBehaviour
{
    public string detail = "This is a instrument";
    public Transform descriptionObj;
    public Transform instrument;
    public Transform PositionObj;
    private Vector3 originalSize,originalPosition; 
    public Quaternion originalRotation;
    public Vector3 newSize, descriptionPosition;
    private bool isRotate=false;
    public static string selected="";
    void Start()
    {
        descriptionObj.GetComponent<TextMesh>().text="";
    }
    void Update()
    {
        if(isRotate)
        {
            //instrument.Rotate(0,0,1);
            instrument.transform.Rotate(new Vector3(0, 0, 1), Space.Self);

        }
    }
    public static string SpliceText(string inputText, int lineLength) {
 
    string[] stringSplit = inputText.Split(' ');
    int charCounter = 0;
    string finalString = "";
 
    for(int i=0; i < stringSplit.Length; i++){
        finalString += stringSplit[i] + " ";
        charCounter += stringSplit[i].Length;
 
        if(charCounter > lineLength){
            finalString += "\n";
            charCounter = 0;
        }
    }
    return finalString;
}
    public void onSelection()
    {
        if(selected=="")
        {
            originalPosition=instrument.transform.position;
            originalSize=instrument.transform.localScale;
            originalRotation=instrument.transform.rotation;

            newSize= originalSize*3;

            instrument.transform.position=PositionObj.transform.position;
            instrument.transform.localScale=newSize;
            isRotate=true;
            //descriptionObj.transform.position=new Vector3(0.0f,3.0f,1.0f);
            selected=gameObject.name;
            Debug.Log(selected);
            switch(selected)
            {
                case "Voltmeter":
                    detail="A voltmeter is an instrument used for measuring electric potential difference between two points in an electric circuit. It is connected in parallel. ";
                    break;
                case "Ammeter":
                    detail="An ammeter (from ampere meter) is a measuring instrument used to measure the current in a circuit. Electric currents are measured in amperes (A), hence the name. The ammeter is usually connected in series with the circuit in which the current is to be measured.";
                    break;
                case "Galvanometer":
                    detail="A galvanometer is an instrument for measuring a small electrical current or a function of the current by deflection of a moving coil.The major significant difference between ammeter and galvanometer is that ammeter shows only the magnitude of the current. Whereas, the galvanometer shows both the direction and magnitude of the current.";
                    break;
                case "Convexlens":
                    detail= "The convex lens is a lens that converges the incident rays towards the principal axis which is relatively thick across the middle and thin at the lower and upper edges.  Convex lenses are used in eyeglasses for correcting farsightedness.";
                    break; 

            }
            descriptionObj.GetComponent<TextMesh>().text= SpliceText(detail,25);
        }
        else if(selected == gameObject.name)
        {
            isRotate=false;
            instrument.transform.position=originalPosition;
            instrument.transform.localScale=originalSize;
            instrument.transform.rotation=originalRotation;
            descriptionObj.GetComponent<TextMesh>().text="";
            selected="";
        }
    }
}
