using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectToPosition_Urmager : MonoBehaviour
{
    public string objectName;
    public GameObject prefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NameOfObject>() != null)
        {
            if (other.gameObject.GetComponent<NameOfObject>().objectName == objectName)
            {
                GameObject spawned = Instantiate(prefab, transform.position, Quaternion.identity);
                spawned.transform.rotation = transform.rotation;
                Destroy(other.gameObject);
            }
        }
    }
}
