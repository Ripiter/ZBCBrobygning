using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class CakeScript : MonoBehaviour

{
    public GameObject prefab;
    public string name;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Stuff");
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
                return new Vector3(transform.position.x, transform.position.y - 0.91f, transform.position.z);
            case "Cake2":
                return new Vector3(transform.position.x, transform.position.y - 0.482f, transform.position.z);
          
            default:
                break;
        }
        return Vector3.zero;
    }
}


