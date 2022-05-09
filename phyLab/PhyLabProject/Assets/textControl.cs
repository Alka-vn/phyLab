using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textControl : MonoBehaviour
{
    List<string> questions = new List<string>() {"Equation of ohm law is","What is kept as constant in ohms law","What is the value of acceleration due to gravity","Acceleration due to gravity(g) is a vector quantity or not","The least count of the Vernier caliper is","What is the value of least count of   screw gauge","What is the unit of resistance?","What is lens makers formula?","What is the unit of refractive power?","The angle of incidence for a ray of light \nhaving zero reflection angle is"};

    List<string> correctAnswer = new List<string>() {"1","3","2","1","3","2","1","1","4","2"};
    int[] visitedQuestions=new int[10];
    public static string selectedAnswer;
    public static bool choiceSelected=false;
    public static int randQuestion=-1;
    public Transform resultObj;
    public Transform scoreObj;
    public static int totalMarks=0;
    public static int questionCount=0;
    public static bool play=false;
    public static int totalCount=10;
    void Start()
    {
        scoreObj.GetComponent<TextMesh>().text="";
        for(int i=0;i<10;i++) 
        {
            visitedQuestions[i]=0;
        }
    }
    
    void Update()
    {
        if(play)
        {
            Debug.Log("Total"+totalCount);
            Debug.Log("Qno"+questionCount);
            scoreObj.GetComponent<TextMesh>().text="";
            
            if(randQuestion==-1)
            {
                resultObj.GetComponent<TextMesh>().text="Select an answer...";
                randQuestion=Random.Range(0,10);
                if(visitedQuestions[randQuestion] == 0)
                {
                    visitedQuestions[randQuestion]=1;
                }
                else
                {
                    while(visitedQuestions[randQuestion]==1)
                    {
                        randQuestion=(randQuestion+1)%10;
                    }
                    visitedQuestions[randQuestion]=1;
                }
                
            }
            
            if(randQuestion>-1)
            {
                GetComponent<TextMesh>().text = questions[randQuestion];
            }
            
            if(choiceSelected)
            {
                questionCount+=1;
                if(correctAnswer[randQuestion] == selectedAnswer)
                {
                    resultObj.GetComponent<TextMesh>().text = "Correct!!!\nClick next to continue";
                    totalMarks+=1;
                }
                else
                {
                    resultObj.GetComponent<TextMesh>().text="Wrong Answer...";
                }
                choiceSelected=false;
            }
            if(questionCount==totalCount)
            {
                play=false;
                scoreObj.GetComponent<TextMesh>().text="Test is Over \n"+totalMarks+"/"+questionCount;
                for(int i=0;i<10;i++) 
                {
                    visitedQuestions[i]=0;
                }
            }
            /* else
            {
                scoreObj.GetComponent<TextMesh>().text="";
            } */
        }
        else
        {
            resultObj.GetComponent<TextMesh>().text="";
            GetComponent<TextMesh>().text="";
        }
        //Debug.Log(questions[randQuestion]);
    }
}
