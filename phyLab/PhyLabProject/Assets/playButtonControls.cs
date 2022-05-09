using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButtonControls : MonoBehaviour
{
    public Transform TitleCard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!textControl.play)
        {
            GetComponent<TextMesh>().text="Play";
            TitleCard.GetComponent<TextMesh>().text="Assessment";
        }
        
    }
    public void onSelection()
    {
        GetComponent<TextMesh>().text="";
        TitleCard.GetComponent<TextMesh>().text="";
        textControl.questionCount=0;
        textControl.totalMarks=0;
        textControl.play=true;
    }
}
