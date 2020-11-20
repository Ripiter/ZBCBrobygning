using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerShowSpriteInChild : MonoBehaviour
{

    public string ObjectNameForTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<NameOfObject>() != null)
        {
            if (collision.gameObject.GetComponent<NameOfObject>().objectName == ObjectNameForTrigger)
            {
                this.gameObject.GetComponentInChildren<MeshRenderer>().material.SetFloat("_Metallic", 1);
                VVSGameManager.instance.pipePlaced++;
                Destroy(collision.gameObject);
            }
        }
    }
}
