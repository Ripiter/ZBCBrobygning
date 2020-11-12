using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class WinDetector_AnlaegsGartner : MonoBehaviour
{
    public GameObject videoplayerObject;

    private bool isDone;


    private void FixedUpdate()
    {
        if (!isDone)
        {
            if (PlantManager.instance.GetTotalCount() == PlantManager.instance.GetTotalToPlant())
            {
                isDone = true;
                videoplayerObject.SetActive(true);
            }
        }
    }
}
