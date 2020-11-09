using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Invest : MonoBehaviour
{

    public InvestManager investManager;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<NameOfObject>() != null)
        {
            if (col.gameObject.GetComponent<NameOfObject>().objectName == "Money")
            {
                investManager.firedCounter++;
                Destroy(col.gameObject);
            }
        }
    }
}
