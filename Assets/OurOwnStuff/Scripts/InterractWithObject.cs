using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractWithObject : MonoBehaviour

{

    GameObject item;
    public GameObject tempParent;
    public Transform guide;
    bool carrying;
    public float range;

    RaycastHit hit;
    int layerMask = 1 << 8;




    // Start is called before the first frame update
    void Start()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    // Update is called once per frame
    void Update()
    {




    }


    void PickUpItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;



        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.position = new Vector3(guide.position.x, guide.position.y, guide.position.z);
                item.transform.rotation = guide.transform.rotation;
                item.transform.parent = tempParent.transform;
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.transform.parent = null;
                item.transform.position = new Vector3(guide.position.x, guide.position.y, guide.position.z);
            }

        }

    }

}
