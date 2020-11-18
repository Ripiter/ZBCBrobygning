using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectToPosition : MonoBehaviour
{
    public string objectName;
    public GameObject prefab;
    public GameObject finishedSet;
    public GameObject winDetector;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NameOfObject>() != null)
        {
            if (other.gameObject.GetComponent<NameOfObject>().objectName == objectName)
            {
                GameObject spawned = Instantiate(prefab, transform.position, Quaternion.identity);
                spawned.transform.rotation = transform.rotation;
                spawned.transform.SetParent(finishedSet.transform);
                Destroy(other.gameObject);
                winDetector.GetComponent<WinDetector_Tjener>().CheckForWin(finishedSet.transform.childCount);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
