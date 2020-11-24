using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurerSpawner : MonoBehaviour
{
    public GameObject prefab;
    public string name;
    float x;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
           StartCoroutine(Spawner());
           
        }
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1);
        x += 0.3f;
        prefab.GetComponent<Rigidbody>().isKinematic = false;
        Instantiate(prefab, new Vector3(-0.45f, x, 4.96f), Quaternion.identity);
    }
}
