using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItemOnCube : MonoBehaviour
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
                Destroy(other.gameObject);
                Destroy(gameObject);
                prefab.GetComponent<Rigidbody>().isKinematic = true;
                Instantiate(prefab, GetVector(other.gameObject.GetComponent<NameOfObject>().objectName), Quaternion.identity);
            }
        }
    }
    public Vector3 GetVector(string objectName)
    {
        switch (objectName)
        {
            case "Tree":
                return new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
            case "Bush":
                return new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            case "Tile":
                return new Vector3(transform.position.x, transform.position.y + -0.1f, transform.position.z);
            default:
                break;
        }
        return Vector3.zero;
    }
}
