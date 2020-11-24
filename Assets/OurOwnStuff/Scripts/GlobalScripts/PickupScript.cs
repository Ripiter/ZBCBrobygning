using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public GameObject mainCamera;
    bool carrying;
    GameObject carriedObject;
    public float distance;
    float curDistance;
    public float smooth;
    float rotateSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        curDistance = distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (carriedObject == null)
            DropObject();

        if (carrying)
        {
            Carry(carriedObject);
            CheckDrop();

            curDistance += Input.GetAxis("Mouse ScrollWheel");
        }
        else
        {
            PickUp();
        }

    }
    void RotateObject(GameObject _o)
    {
        if (Input.GetKey(KeyCode.RightArrow))
            _o.transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
            _o.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            _o.transform.Rotate(Vector3.left * rotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            _o.transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
    }


    void Carry(GameObject _o)
    {
        _o.transform.position = Vector3.Lerp(_o.transform.position,
            mainCamera.transform.position + mainCamera.transform.forward * curDistance,
            smooth * Time.deltaTime);

        if (_o.GetComponent<MovableScript>() != null)
        {
            if (_o.GetComponent<MovableScript>().canRotate)
                RotateObject(_o);
        }
    }

    void PickUp()
    {
        if (Input.GetMouseButton(0))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                MovableScript movable = hit.collider.GetComponent<MovableScript>();
                if (movable != null)
                {
                    carrying = true;
                    carriedObject = movable.gameObject;
                    if (movable.gameObject.GetComponent<Rigidbody>() != null)
                    {
                        movable.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    }
                    PickupManager.instance.ItemWasPickedUp(hit.collider.gameObject);
                }
            }
        }
    }


    void CheckDrop()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DropObject();
        }
    }

    void DropObject()
    {
        carrying = false;
        if (carriedObject != null)
            carriedObject.GetComponent<Rigidbody>().isKinematic = false;

        PickupManager.instance.ItemWasDropped(carriedObject);
        curDistance = distance;
        carriedObject = null;
    }
}
