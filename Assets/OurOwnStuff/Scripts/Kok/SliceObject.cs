using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceObject : MonoBehaviour
{

    public GameObject slicedObj;
    public int numberOfSlice;
    public bool canBeSliced = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<NameOfObject>() != null) 
        { 
            if (collision.gameObject.GetComponent<NameOfObject>().objectName == "Knife") 
            {
                if (canBeSliced == false) 
                {
                    return;
                }

                if (numberOfSlice > 0) 
                {
                    GameObject temp;
                    Instantiate(slicedObj,transform.position,Quaternion.identity, transform.parent);
                    numberOfSlice--;
                }

                if (numberOfSlice == 0) 
                {
                    Destroy(this.gameObject);
                }

            }
        }
    }
}
