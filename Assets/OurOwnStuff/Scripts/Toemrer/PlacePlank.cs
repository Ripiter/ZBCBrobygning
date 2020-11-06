using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class PlacePlank : MonoBehaviour
{
    public string objectName;
    public GameObject prefab;
    float bigPlanks = 13.88071f;
    float smallPlanks = 6.89753f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Test");
        if (col.gameObject.GetComponent<NameOfObject>() != null)
        {
            if (col.gameObject.GetComponent<NameOfObject>().objectName == objectName)
            {
                if (col.gameObject.transform.localScale.x == gameObject.transform.localScale.x) // is the planks the same length as the plankholder
                {
                    GameObject spawned = Instantiate(prefab, transform.position, Quaternion.identity);
                    prefab.GetComponent<Rigidbody>().isKinematic = true;
                    spawned.transform.rotation = transform.rotation;
                    spawned.transform.localScale = transform.localScale;
                    Destroy(col.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}
