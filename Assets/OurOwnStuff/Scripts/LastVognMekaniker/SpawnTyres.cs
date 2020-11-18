using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTyres : MonoBehaviour, IPickUp
{
    public GameObject prefab;
    public GameObject cube;
    public string name;
    public bool isTaken = true; 
    // Start is called before the first frame update
    void Start()
    {
        PickupManager.instance.AddListener(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<NameOfObject>().objectName != null)
        {
            if (other.gameObject.GetComponent<NameOfObject>().objectName == "FrontTyre" && isTaken == false)
            {

                Destroy(other.gameObject);
                Destroy(gameObject);
                Instantiate(other.gameObject, GetVector(other.gameObject.GetComponent<NameOfObject>().objectName), Quaternion.identity);
                isTaken = true;
                
               
            }
            else if (other.gameObject.GetComponent<NameOfObject>().objectName == "BackTyre" && isTaken == false)
            {

                Destroy(other.gameObject);
                Destroy(gameObject);
                Instantiate(prefab, GetVector(other.gameObject.GetComponent<NameOfObject>().objectName), Quaternion.identity);
                Instantiate(cube, new Vector3(-1.311f, 1.537f, -13.719f), Quaternion.Euler(0, 0, 90));
                isTaken = true;

            }
            else if (other.gameObject.GetComponent<NameOfObject>().objectName == "RightSideTyreBack" && isTaken == false)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                Instantiate(prefab, GetVector(other.gameObject.GetComponent<NameOfObject>().objectName), Quaternion.Euler(0,180,0));
                Instantiate(cube, new Vector3(0.59f, 1.52f, -13.573f), Quaternion.Euler(0,0,90));
                isTaken = true;
            }
            else if (other.gameObject.GetComponent<NameOfObject>().objectName == "FrontTyreRight" && isTaken == false)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                Instantiate(prefab, GetVector(other.gameObject.GetComponent<NameOfObject>().objectName), Quaternion.Euler(0,180,0));
                isTaken = true;
            }
        }
    }
    public Vector3 GetVector(string objectName)
    {
        switch (objectName)
        {
            case "FrontTyre":
                return new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
            case "BackTyre":
                return new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z + 0.15f);
            case "RightSideTyreBack":
                return new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
            case "FrontTyreRight":
                return new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);

            default:
                break;
        }
        return Vector3.zero;
    }

    public void PickedUp(GameObject _pickedObject)
    {
        if(_pickedObject.GetComponent<NameOfObject>() != null)
        {
            if(_pickedObject.GetComponent<NameOfObject>().objectName == name)
            {
                if(_pickedObject.GetComponent<MovableScript>().isTrue == false)
                    isTaken = false;
            }
        }
    }

    public void Droped(GameObject _droped)
    {
       
    }
}
