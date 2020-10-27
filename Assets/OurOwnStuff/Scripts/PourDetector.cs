using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    public int pourThreshHold = 35;
    public Transform origin;
    public GameObject streamPrefab;

    private bool isPouring = false;
    private StreamBottle currectStream;

    public string nameOfObject;
    

    void Update()
    {
        if(nameOfObject == "bottle")
        {
            bool pourCheck = CalculatePourAngle() < pourThreshHold;

            PouringStateChange(pourCheck);
        }
    }

    void PouringStateChange(bool pourCheck)
    {
        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }
    }

    public void StartPouring()
    {
        //PouringStateChange(true);
        //transform.Rotate(Vector3.left * 90);
    }

    public void StopPouring()
    {
        //transform.Rotate(Vector3.right * 90);
        //PouringStateChange(false);
    }


   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PouringStateChange(!isPouring);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PouringStateChange(!isPouring);
        }
    }

    void StartPour()
    {
        currectStream = CreateStream();

        if(nameOfObject == "vaske")
            currectStream.GetComponent<LineRenderer>().startColor = Color.blue;       

        currectStream.Begin();
    }

    void EndPour()
    {
        currectStream.End();
        currectStream = null;
    }

    float CalculatePourAngle()
    {
        return transform.forward.y * Mathf.Rad2Deg;
    }

    StreamBottle CreateStream()
    {
        GameObject streamObj = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return streamObj.GetComponent<StreamBottle>();
    }
}
