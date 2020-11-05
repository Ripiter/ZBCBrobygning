using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SmeltCollision : MonoBehaviour
{

    public GameObject collideWith;
    public GameObject[] disableObjects;
    public GameObject enableObject;

    public float smeltingTime;
    private bool isInSmeltingArea;
    private bool smeltDone;


    private float smeltingRemaining;


    // Start is called before the first frame update
    void Start()
    {
        isInSmeltingArea = false;
        smeltingRemaining = smeltingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInSmeltingArea)
        {
            if (!smeltDone)
            {
                if (smeltingRemaining > 0)
                {
                    smeltingRemaining -= Time.deltaTime;
                }
                else
                {
                    smeltDone = true;
                    SmeltDone();
                }
            }
        }
    }

    private void SmeltDone()
    {
        for (int i = 0; i < disableObjects.Length; i++)
        {
            disableObjects[i].SetActive(false);
        }
        enableObject.SetActive(true);
        Debug.Log("Success");
    }


    public void OnTriggerEnter(Collider other)
    {
        if (enableObject.activeSelf == false)
        {
            if (other.name == collideWith.name)
            {
                isInSmeltingArea = true;
            }
        }

    }

    public void OnTriggerExit(Collider other)
    {
       if (enableObject.activeSelf == false)
        {
            if (other.name == collideWith.name)
            {
                isInSmeltingArea = true;
            }
        } 
    }

}
