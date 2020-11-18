using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class Interactable_Maler : MonoBehaviour
{
    public GameObject spawnObject;
    public PaintSpawn spawner;
    public GameObject finalColor;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void InteractWithPlayer()
    {
        Debug.Log("ded " + gameObject.name);
     
        if (gameObject.name == "ClearBtn")
        {
            spawner.SpawnPaint(Color.clear);
        }
        else if(gameObject.name == "ResetBtn")
        {
            finalColor.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
        else
        {
            spawner.SpawnPaint(GetComponent<Renderer>().material.color);
        }
    }
}