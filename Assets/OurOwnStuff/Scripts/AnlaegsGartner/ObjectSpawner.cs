using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject SpawnObject;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frames
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Spawner());
        }
    }

    IEnumerator Spawner()
    {
        if (gameObject.GetComponent<NameOfObject>() != null)
        {
            string nameOfObject = gameObject.GetComponent<NameOfObject>().objectName;
            if (nameOfObject == "TreeSpawnerCube")
            {
                Instantiate(SpawnObject, new Vector3(50, 0, 25), Quaternion.identity);
            }
            else if (nameOfObject == "BushSpawnerCube")
            {
                Instantiate(SpawnObject, new Vector3(45, 0.5f, 25), Quaternion.identity);
            }
            else if (nameOfObject == "TileSpawnerCube")
            {
                Instantiate(SpawnObject, new Vector3(55, 0, 25), Quaternion.identity);
            }
            yield return new WaitForSeconds(1);
        }
    }


}
