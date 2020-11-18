using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDetector_Mekaniker : MonoBehaviour
{

    public bool partoneComplete;
    public bool parttwoComplete;
    public GameObject videoPlayer;


    public void UpdateParts(int i)
    {
        if (i == 1)
        {
            if (parttwoComplete)
            {
                videoPlayer.SetActive(true);
            }
            else
                partoneComplete = true;
        }
        else if (i == 2)
        {
            if (partoneComplete)
            {
                videoPlayer.SetActive(true);
            }
            else
                parttwoComplete = true;
        }
    }

}
