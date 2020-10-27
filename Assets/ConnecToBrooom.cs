using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConnecToBrooom : MonoBehaviour
{


    public string objectname = "";

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nut"))
        {
            rb.isKinematic = true;
        }

    }
}
