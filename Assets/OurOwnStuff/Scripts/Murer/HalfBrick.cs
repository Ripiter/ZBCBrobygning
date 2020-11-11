using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfBrick : MonoBehaviour
{
  
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        
            if (other.gameObject.GetComponent<NameOfObject>().objectName == "Brick 1")
            {

                Destroy(other.gameObject);
                Destroy(gameObject);
                prefab.GetComponent<Rigidbody>().isKinematic = false;
                Instantiate(prefab, GetVector(other.gameObject.GetComponent<NameOfObject>().objectName), Quaternion.identity);
                other.isTrigger = false;
            }
        
    }
    public Vector3 GetVector(string objectName)
    {
        switch (objectName)
        {
            case "Brick 1":

                return new Vector3(transform.position.x - 0.28f, transform.position.y + 0.27f, transform.position.z + 0.58f);
        }
        return Vector3.zero;
    }
}
    
