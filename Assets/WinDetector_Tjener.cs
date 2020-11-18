using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDetector_Tjener : MonoBehaviour
{
    public int amountOfObjects;
    public GameObject videoPlayer;
    private bool isComplete;

    public void CheckForWin(int amount)
    {
        if (!isComplete)
        {
            if (amountOfObjects == amount)
            {
                isComplete = true;
                videoPlayer.SetActive(true);
            }
        }
    }

}
