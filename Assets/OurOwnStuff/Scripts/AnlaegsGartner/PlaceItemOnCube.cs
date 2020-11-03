using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceItemOnCube : MonoBehaviour
{

    public GameObject prefab;
    public string name;

    string CurrentlyCount;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
        //Task.Add($"Plant Træere {TreeCount} / {TreesToPlant}");
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NameOfObject>() != null)
        {
            if (other.gameObject.GetComponent<NameOfObject>().objectName == name)
            {
                Debug.Log("Tree Planted");
                PlantManager.instance.AddToCount(name);
                PlantManager.instance.SpawnObject(other.gameObject, prefab, GetVector(other.gameObject.GetComponent<NameOfObject>().objectName));
                Destroy(gameObject);
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
