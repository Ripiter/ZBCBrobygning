using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public GameObject mainCamera;
    bool carrying;
    GameObject carriedObject;
    public float distance;
    public float smooth;
    // Start is called before the first frame update
    void Start()
    {

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

            //Vector3 normalizedDirection = (carriedObject.transform.position - transform.position).normalized;
            //carriedObject.transform.Translate(normalizedDirection * Input.GetAxis("Mouse ScrollWheel"));
            distance += Input.GetAxis("Mouse ScrollWheel");
        }
        else
        {
            PickUp();
        }

    }
    void RotateObject()
    {
        carriedObject.transform.Rotate(5, 10, 15);
    }

        float rotateSpeed = 100;

    void Carry(GameObject _o)
    {
        _o.transform.position = Vector3.Lerp(_o.transform.position,
            mainCamera.transform.position + mainCamera.transform.forward * distance,
            smooth * Time.deltaTime);

        if (Input.GetKey(KeyCode.E))
        {
            _o.transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.Q))
            _o.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
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
                    movable.gameObject.GetComponent<Rigidbody>().isKinematic = true;

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
        if(carriedObject != null)
            carriedObject.GetComponent<Rigidbody>().isKinematic = false;

        if (carriedObject != null)
        {
            if (carriedObject.GetComponent<MovableScript>() != null)
            {

                if (carriedObject.GetComponent<MovableScript>().isBottle)
                    carriedObject.GetComponent<PourDetector>().StopPouring();
            }
        }

        carriedObject = null;

    }
}
