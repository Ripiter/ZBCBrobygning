using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RayCastSphere : MonoBehaviour
{

    public float xSize;
    public float lookDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float maxDistance = lookDistance;
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool isHit = Physics.SphereCast(transform.position, xSize / 2, transform.forward, out hit, maxDistance);
            if (isHit)
            {
                Debug.Log("Hit stuff");
            }
            else
            {
                Debug.Log("NoHit stuff");
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    float maxDistance = lookDistance;
    //    RaycastHit hit;

    //    bool isHit = Physics.SphereCast(transform.position, xSize / 2, transform.forward, out hit, maxDistance);
    //    if (isHit)
    //    {      
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            Debug.Log("Success");
    //        }
    //        else
    //        {
    //            Debug.Log("Failed");
    //        }
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
    //        Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, xSize / 2);
    //    }
    //    else
    //    {
    //        Gizmos.color = Color.green;
    //        Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
    //    }
    //}

}
