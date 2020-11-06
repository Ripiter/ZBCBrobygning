using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emne : MonoBehaviour
{
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
