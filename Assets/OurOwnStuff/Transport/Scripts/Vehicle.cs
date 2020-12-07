using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public enum SteringMode
    {
        Realistic,
        Static,
    }

    public Camera Camera = null;
    public float CameraMaxMovement = 1.0f;
    private Vector3 cameraStartPos;

    public float MaxSpeed = 100.0f;
    public float MaxReverseSpeed = 10.0f;
    public float AccelerationTime = 6.0f;
    public float DefaultDeaccelerationTime = 12.0f;
    public float BreakDeaccelerationTime = 12.0f;

    public float Speed = 0.0f;
    public SteringMode Stering = SteringMode.Realistic;
    public float MaxStering = 2.0f;
    public float SteringSpeed = 0.2f;

    public bool IsStarted = false;

    private float stering = 0.0f;
    private float steringForce = 0.0f;

    bool isReverse = false;
    bool isBreaking = false;

    float KmhToUnits(float kmh)
    {
        return (kmh / 2.0f) / 3.6f;
    }
    float GetAccelration(float time)
    {
        // (a = v / t)
        return (100.0f / 3.6f) / (time) * (Time.deltaTime * 3.6f);
    }

    void EventCameraGotoX(float x)
    {
        if (Camera != null)
        {
            float delta = x - Camera.transform.localPosition.x;
            if (delta != 0.0f)
                Camera.transform.localPosition += new Vector3(delta * Time.deltaTime, 0.0f);
        }
    }
    void EventCameraGotoZ(float z)
    {
        if (Camera != null)
        {
            float delta = z - Camera.transform.localPosition.z;
            if (delta != 0.0f)
                Camera.transform.localPosition += new Vector3(0.0f, 0.0f, delta * Time.deltaTime);
        }
    }

    void EventSpeedLimits(float maxSpeed)
    {
        if (Speed > maxSpeed)
            Speed = maxSpeed;

        if (Speed < 0.0f)
            Speed = 0.0f;
    }
    void EventMoveCar(KeyCode key, float direction, float maxSpeed)
    {
        if ((Input.GetKey(key)) && (IsStarted))
        {
            Speed += GetAccelration(AccelerationTime);
            EventCameraGotoZ(cameraStartPos.z + (Speed / 100.0f));
        }
        else if(!isBreaking)
        {
            Speed -= GetAccelration(DefaultDeaccelerationTime);
            EventCameraGotoZ(cameraStartPos.z);
        }

        EventSpeedLimits(maxSpeed);

        float cSpeed = -KmhToUnits(Speed) * direction * Time.deltaTime;

        float dx = cSpeed * Mathf.Sin(stering);
        float dy = cSpeed * Mathf.Cos(stering);
        //GetComponent<Rigidbody>().velocity += new Vector3(dx, 0.0f, dy);
        
        transform.position += new Vector3(dx, 0.0f, dy);
    }
    void EventStering()
    {
        if (Stering == SteringMode.Realistic)
        {
            if (steringForce < MaxStering)
                steringForce += SteringSpeed * Time.deltaTime;
        }
        else if (Stering == SteringMode.Static)
        {
            steringForce = MaxStering;
        }
    }
    void EventSteringCar(float direction)
    {
        float steringSpeed = 0.0f;

        if (Stering == SteringMode.Realistic)
        {
            float speed = Speed;
            if (speed > 20)
                speed = 20;

            steringSpeed = steringForce * (speed / 25.0f);
        }
        else if (Stering == SteringMode.Static)
        {
            steringSpeed = steringForce;
        }


        if (Input.GetKey(KeyCode.D))
        {
            stering += direction * steringSpeed * Time.deltaTime;
            EventStering();
            EventCameraGotoX(direction * cameraStartPos.x - CameraMaxMovement);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            stering -= direction * steringSpeed * Time.deltaTime;
            EventStering();
            EventCameraGotoX(direction * cameraStartPos.x + CameraMaxMovement);
        }
        else
        {
            steringForce = 0.0f;
            EventCameraGotoX(cameraStartPos.x);
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, stering * 180.0f / Mathf.PI, transform.eulerAngles.z );
    }
    void EventBreakCar(float direction, KeyCode key)
    {
        if (Input.GetKey(key))
        {
            Speed -= GetAccelration(BreakDeaccelerationTime);
            EventCameraGotoZ(cameraStartPos.z - 1.0f);
            isBreaking = true;
        }
        else
            isBreaking = false;

        EventSpeedLimits(MaxSpeed);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Camera != null)
            cameraStartPos = Camera.transform.localPosition;
        else
            cameraStartPos = new Vector3(0.0f, 0.0f);


       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            // == betyder at du checker om værdien er ligmed en anden værdig
            // = betyder at du sæter værdien til en anden værdig

            if (IsStarted == true)
                IsStarted = false;
            else
                IsStarted = true;
        }


        if (Speed == 0.0f)
        {
            if (Input.GetKey(KeyCode.W))
                isReverse = false;
            else if (Input.GetKey(KeyCode.S))
                isReverse = true;
        }

        if (!isReverse)
        {
            EventMoveCar(KeyCode.W, 1.0f, MaxSpeed);
            EventSteringCar(1.0f);
            EventBreakCar(1.0f, KeyCode.S);
        }
        else
        {
            EventMoveCar(KeyCode.S, -1.0f, MaxReverseSpeed);
            EventSteringCar(-1.0f);
            EventBreakCar(-1.0f, KeyCode.W);
        }
        
    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag != "Floor")
        {
            Speed = 0.0f;
        }
    }
}
