using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSpawn : MonoBehaviour
{
    public GameObject spawnObject;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPaint(Color color)
    {
        GameObject spawn = Instantiate(spawnObject, spawnPoint.position, Quaternion.identity);
        spawn.GetComponent<Renderer>().material.color = color;
    }
    
    
}
