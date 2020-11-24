using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maler_Manager : MonoBehaviour, IInteract
{
    public PaintSpawn spawner;
    public GameObject finalColor;

    public void Interacted(GameObject _object)
    {
        if (_object.GetComponent<InteractScript>().StringValue == "ClearBtn")
        {
            spawner.SpawnPaint(Color.clear);
        }
        else if (_object.GetComponent<InteractScript>().StringValue == "ResetBtn")
        {
            finalColor.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
        else
        {
            spawner.SpawnPaint(_object.GetComponent<Renderer>().material.color);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InteractManager.instance.AddListener(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
