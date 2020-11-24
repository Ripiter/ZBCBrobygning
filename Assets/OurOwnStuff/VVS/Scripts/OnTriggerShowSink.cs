using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerShowSink : MonoBehaviour
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
                this.transform.GetChild(0).gameObject.SetActive(true);
                VVSGameManager.instance.sinkPlaced++;
                Destroy(collision.gameObject);
            }
        }
    }
}
