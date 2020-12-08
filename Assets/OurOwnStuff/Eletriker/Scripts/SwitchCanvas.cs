using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCanvas : MonoBehaviour
{
    public GameObject onObject;
    public GameObject toCanvas;
    public string disabledObjectTag;


    public void Switch()
    {
        onObject.GetComponent<MovementPlayer>().menuCanvas = toCanvas;
        onObject.GetComponent<MovementPlayer>().ChangeCanvas();
        if (onObject.gameObject.tag == disabledObjectTag)
        {
            onObject.GetComponent<MovementPlayer>().ChangeCanvas();
        }
    }
}
