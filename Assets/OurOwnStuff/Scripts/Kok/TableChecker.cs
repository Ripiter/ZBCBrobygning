using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableChecker : MonoBehaviour
{
    public GameObject RecipesObj;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<NameOfObject>() != null) 
        {

            if (collision.gameObject.GetComponent<NameOfObject>().objectName == "Plate") 
            {
                RecipesObj.GetComponent<Recipes>().SpawnPlate();
                RecipesObj.GetComponent<Recipes>().ActiveUI();
            }

        }
    }
}
