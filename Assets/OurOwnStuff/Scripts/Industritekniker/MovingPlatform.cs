using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public double xSpeed = 0;
    public double ySpeed = 0;
    public double zSpeed = 0;

    public float xDistance = 0;
    public float yDistance = 0;
    public float zDistance = 0;

    private double x = 0;
    private double y = 0;
    private double z = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x += xSpeed * Time.deltaTime;
        y += ySpeed * Time.deltaTime;
        z += zSpeed * Time.deltaTime;
        transform.position += new Vector3(xDistance * (float)Math.Sin(x), yDistance * (float)Math.Cos(y), zDistance * (float)Math.Sin(z));    
    }
}
