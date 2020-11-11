using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MurerItemonCube : MonoBehaviour
{

   
    public string name;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NameOfObject>().objectName != null)
        {
            if (other.gameObject.GetComponent<NameOfObject>().objectName == "Brick 1")
            {

                Destroy(other.gameObject);
                Destroy(gameObject);
                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                Instantiate(other.gameObject, GetVector(other.gameObject.GetComponent<NameOfObject>().objectName), Quaternion.identity);
                other.isTrigger = false;
            }
            else if (other.gameObject.GetComponent<NameOfObject>().objectName == "Brick 2")
            {

                Destroy(other.gameObject);
                Destroy(gameObject);
                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                Instantiate(other.gameObject, GetVector(other.gameObject.GetComponent<NameOfObject>().objectName), Quaternion.identity);
                other.isTrigger = false;
            }
        }
    }
    public Vector3 GetVector(string objectName)
    {
        switch (objectName)
        {
            case "Brick 1":
                
                return new Vector3(transform.position.x - 0.26f, transform.position.y + 0.27f, transform.position.z + 0.35f);
           
            case "Brick 2":

                return new Vector3(transform.position.x - 0.28f , transform.position.y + 0.3f, transform.position.z - 0.23f);
         
        }

        return Vector3.zero;
    }
  
}
