using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class PlaceEmne : MonoBehaviour
{
    public GameObject prefab;
    Rigidbody rigidbody;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        GetComponent<Renderer>().enabled = false;
    }

    public bool hasCube = false;

    // Update is called once per frame



    //private void OnCollisionEnter(Collision other)
    //{
    //    Emne emne = other.collider.GetComponent<Emne>();
    //    if (emne != null)
    //    {
    //        Destroy(emne.gameObject);
    //        GetComponent<Renderer>().enabled = true;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<NameOfObject>() != null)
        {
            if(other.gameObject.GetComponent<NameOfObject>().objectName == "Cube")
            {
                Destroy(other.gameObject);
                GetComponent<Renderer>().enabled = true;
                hasCube = true;
                text.text = "Tryk på den grønne knap for at starte maskinen";
            }
        }

    }

    public void SpawnCube()
    {
        Instantiate(prefab, transform.position, Quaternion.Euler(-90, 0, 0));
     
        GetComponent<Renderer>().enabled = false;
        hasCube = false;
    }

}