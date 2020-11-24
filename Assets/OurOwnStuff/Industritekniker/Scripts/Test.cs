using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public double xSpeed = 0;
    public double ySpeed = 0;
    public double zSpeed = 0;


    public float kx1 = 0;
    public float ky1 = 0;
    public float kz1 = 0;
    public float kx2 = 0;
    public float ky2 = 0;
    public float kz2 = 0;
    public float kx3 = 0;
    public float ky3 = 0;
    public float kz3 = 0;


    private double x = 0;
    private double y = 0;
    private double z = 0;



    // Start is called before the first frame update
    void Start()
    {
        x += xSpeed * Time.deltaTime;
        y += ySpeed * Time.deltaTime;
        z += zSpeed * Time.deltaTime;
        transform.position += new Vector3(kx1, ky1, kz1);
        transform.position += new Vector3(kx2, ky2, kz2);
        transform.position += new Vector3(kx3, ky3, kz3);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
