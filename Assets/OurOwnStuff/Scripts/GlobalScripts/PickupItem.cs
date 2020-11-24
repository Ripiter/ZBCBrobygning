using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    public GameObject lookingAtObj;
    public bool carrying;
    [SerializeField]
    public float range = 5f;
    public float currentRange;

    public static bool PlayerCarring { get; set; }

    // Use this for initialization
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        

        if (item != null && item.GetComponent<Rigidbody>() != null)
        {
            if (carrying == false)
            {
                if ((guide.transform.position - transform.position).sqrMagnitude < range * range)
                {
                   Pickup();
                   carrying = true;
                   PlayerCarring = carrying;
                }
            }
            else if (carrying == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Drop();
                    carrying = false;
                    PlayerCarring = carrying;
                    item = null;
                }
            }
        }
        else
        {
            if ( Physics.Raycast(ray, out hitInfo) )
            {
                GameObject hitObject = hitInfo.transform.gameObject;
                lookingAtObj = hitObject;
                currentRange = hitInfo.distance;
                if(hitObject.tag == "Selectable")
                {
                    if(Input.GetKeyDown(KeyCode.F))
                    {
                        item = hitObject;
                    }
                }
            }
        }
    }
    public void Pickup()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = new Vector3(guide.position.x, guide.position.y, guide.position.z);
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
    }
    public void Drop()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = new Vector3(guide.position.x, guide.position.y, guide.position.z);
    }
}

