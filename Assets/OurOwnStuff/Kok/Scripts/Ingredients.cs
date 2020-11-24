using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{

    public bool Cooked = false;
    public int CookingTime;
    public Material CookedMat;

    public void Cook() 
    {
        if (Cooked) 
        {
            return;
        }


        gameObject.GetComponent<Renderer>().material = CookedMat;

        Debug.Log("Cooking");

        Cooked = true;
    }
}
