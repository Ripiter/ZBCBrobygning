using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawPlank : MonoBehaviour
{
    public string objectName;
    public GameObject prefab;
    string test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Plank") && gameObject.CompareTag("Sawmachine"))
        {
            if (col.gameObject.GetComponent<MovableScript>().isBottle)
            {
                GameObject spawned = Instantiate(prefab, col.transform.position, Quaternion.identity);
                GameObject spawned2 = Instantiate(prefab, col.transform.position, Quaternion.identity);
                spawned.transform.localScale = new Vector3(prefab.transform.localScale.x / 2, col.transform.localScale.y, col.transform.localScale.z);
                spawned2.transform.localScale = new Vector3(prefab.transform.localScale.x / 2, col.transform.localScale.y, col.transform.localScale.z);
                Destroy(col.gameObject);
            }
            //spawned.transform.position = gameObject.transform.position;
        }
    }
}
