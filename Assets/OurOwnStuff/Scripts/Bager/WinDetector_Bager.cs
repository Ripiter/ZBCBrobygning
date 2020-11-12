using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDetector_Bager : MonoBehaviour
{
    public GameObject videoplayerObject;
    public GameObject ovenObject;

    private bool isDone;

    private void FixedUpdate()
    {
        if (!isDone)
        {
            GameObject cakeDone = GameObject.Find("cleancake 2 1(Clone)");
            if (ovenObject.GetComponent<BakeBread>().isBaked && cakeDone != null)
            {
                isDone = true;
                videoplayerObject.SetActive(true);
            }
        }
    }
}
