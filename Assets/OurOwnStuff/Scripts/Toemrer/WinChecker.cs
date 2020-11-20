using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinChecker : MonoBehaviour
{
    public int completedPlanks;
    public int completedAt;
    public GameObject videoPlayer;

    public static WinChecker instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }


    public void UpdateWin()
    {
        completedPlanks++;
        if (completedPlanks >= completedAt)
        {
            videoPlayer.SetActive(true);
        }
    }
}
