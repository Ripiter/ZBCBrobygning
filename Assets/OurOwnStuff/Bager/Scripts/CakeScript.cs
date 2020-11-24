using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class CakeScript : MonoBehaviour

{
    public GameObject prefab;
    public string name;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NameOfObject>() != null)
        {
            if (other.gameObject.GetComponent<NameOfObject>().objectName == name)
            {                
                Instantiate(prefab, GetVector(other.gameObject.GetComponent<NameOfObject>().objectName), Quaternion.identity);
                
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
    public Vector3 GetVector(string objectName)
    {
        switch (objectName)
        {
            case "Cake1":
                return new Vector3(transform.position.x, transform.position.y, transform.position.z);
            case "Cake2":
                return new Vector3(transform.position.x, transform.position.y, transform.position.z);
          
            default:
                break;
        }
        return Vector3.zero;
    }
}


