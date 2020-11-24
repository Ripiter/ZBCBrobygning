using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject SpawnObject;

    private int spawnedTrees = 0;
    public int MaxTreeObjectToSpawn = 5;

    private int spawnedBush = 0;
    public int MaxBushObjectToSpawn = 7;

    private int spawnedTile = 0;
    public int MaxTileObjectToSpawn = 13;
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
                if (spawnedTrees <= MaxTreeObjectToSpawn)
                {
                    spawnedTrees++;
                    Instantiate(SpawnObject, new Vector3(50, 0, 25), Quaternion.identity);
                }
                else
                {
                    DestroyImmediate(SpawnObject, true);
                }
            }
            else if (nameOfObject == "BushSpawnerCube")
            {
                if (spawnedBush <= MaxBushObjectToSpawn)
                {
                    spawnedBush++;
                    Instantiate(SpawnObject, new Vector3(45, 0.5f, 25), Quaternion.identity);
                }
                else
                {
                    DestroyImmediate(SpawnObject, true);
                }
            }
            else if (nameOfObject == "TileSpawnerCube")
            {
                if (spawnedTile <= MaxTileObjectToSpawn)
                {
                    spawnedTile++;
                    Instantiate(SpawnObject, new Vector3(55, 0, 25), Quaternion.identity);
                }
                else
                {
                    DestroyImmediate(SpawnObject, true);
                }
            }
            yield return nameOfObject;
        }


    }
}
