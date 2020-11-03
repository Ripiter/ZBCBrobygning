using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawnersalg : MonoBehaviour
{
    public GameObject prefab;
    public string name;
    public Text text;
    public int count;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(count);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        if (other.gameObject.GetComponent<NameOfObject>().objectName != null)
        {
            if (other.gameObject.GetComponent<NameOfObject>().objectName == name)
            {

                Destroy(other.gameObject);
                Destroy(gameObject);
                switch (other.gameObject.GetComponent<NameOfObject>().objectName)
                {
                    case "Cola":
                        prefab.GetComponent<Rigidbody>().isKinematic = true;
                        Instantiate(prefab, GetVector(other.gameObject.GetComponent<NameOfObject>().objectName), Quaternion.Euler(-90f, -90f, 0));
                        count++;

                        break;
                    case "Pringles":
                        prefab.GetComponent<Rigidbody>().isKinematic = true;
                        Instantiate(prefab, GetVector(other.gameObject.GetComponent<NameOfObject>().objectName), Quaternion.identity);
                        count++;
                        break;
                    case "Peanuts":
                        prefab.GetComponent<Rigidbody>().isKinematic = true;
                        Instantiate(prefab, GetVector(other.gameObject.GetComponent<NameOfObject>().objectName), Quaternion.identity);
                        count++;
                        break;
                    default:
                        break;
                }

            }
        }
    }
    public Vector3 GetVector(string objectName)
    {
        switch (objectName)
        {
            case "Cola":
                return new Vector3(transform.position.x, transform.position.y + 0.35f, transform.position.z);
            case "Pringles":
                return new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            case "Peanuts":
                return new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z);
            default:
                break;
        }
        return Vector3.zero;
    }




}
