using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{
    public Image imageGaze;

    public float totalTime=2;

    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 10;
    private RaycastHit _hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gvrStatus)
        {
            gvrTimer+= Time.deltaTime;
            imageGaze.fillAmount=gvrTimer/totalTime;
        }
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0f)); 
        if(Physics.Raycast(ray,out _hit,distanceOfRay))
        {
            if(imageGaze.fillAmount == 1 && _hit.transform.CompareTag("Instrument"))
            {
                _hit.transform.gameObject.GetComponent<instrumentControl>().onSelection();
            }
            else if(imageGaze.fillAmount == 1 && _hit.transform.gameObject.name == "Rheostat")
            {
                _hit.transform.gameObject.GetComponent<rheostatControl>().onSelection();
            }
            else if(imageGaze.fillAmount == 1 && _hit.transform.gameObject.name == "MeterBridge")
            {
                _hit.transform.gameObject.GetComponent<meterbridgeControl>().onSelection();
            }
            else if(imageGaze.fillAmount == 1 && _hit.transform.CompareTag("plugKey"))
            {
                _hit.transform.gameObject.GetComponent<plugKey>().onSelection();
            }
            else if(imageGaze.fillAmount == 1 && _hit.transform.gameObject.name == "cell")
            {
                _hit.transform.gameObject.GetComponent<cellControl>().onSelection();
            }
            /* else if(imageGaze.fillAmount == 1 && _hit.transform.CompareTag("Assessment"))
            {
                imageGaze.fillAmount=0;
                switch (_hit.transform.gameObject.name)
                {
                    case "1":
                        _hit.transform.gameObject.GetComponent<text1>().onSelection();
                        break;
                    case "2":
                        _hit.transform.gameObject.GetComponent<text2>().onSelection();
                        break;
                    case "3":
                        _hit.transform.gameObject.GetComponent<text3>().onSelection();
                        break;
                    case "4":
                        _hit.transform.gameObject.GetComponent<text4>().onSelection();
                        break; 
                    case "play":
                        _hit.transform.gameObject.GetComponent<playButtonControls>().onSelection();
                        break;
                    case "Next":
                        _hit.transform.gameObject.GetComponent<nextClick>().onSelection();
                        break;
                    default:
                        break;
                }
            } */
        }
    }
    
    public void GVROn()
    {
        gvrStatus=true;
    }
    public void GVROff()
    {
        gvrStatus=false;
        gvrTimer=0;
        imageGaze.fillAmount=0;
    }
}
