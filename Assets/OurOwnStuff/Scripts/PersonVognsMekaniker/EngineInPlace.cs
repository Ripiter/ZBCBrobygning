using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineInPlace : MonoBehaviour
{
    public string NameOfObject;
    public GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NameOfObject>() != null)
        {
            print(other.gameObject.GetComponent<NameOfObject>().objectName);
            if (other.gameObject.GetComponent<NameOfObject>().objectName == NameOfObject)
            {
                GameObject spawned =  Instantiate(Prefab, transform);
                spawned.transform.localScale = other.transform.localScale;
                Destroy(other.gameObject);
            }
        }
    }
}
