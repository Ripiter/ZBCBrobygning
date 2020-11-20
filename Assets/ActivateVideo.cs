using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateVideo : MonoBehaviour
{
    public static ActivateVideo instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void StartVideo()
    {
        gameObject.GetComponent<VideoPlayerScript>().enabled = true;
    }
}
