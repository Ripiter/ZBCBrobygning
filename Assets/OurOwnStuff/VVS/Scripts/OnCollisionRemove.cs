using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OnCollisionRemove : MonoBehaviour
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
                VVSGameManager.instance.pipeFixed++;
                Destroy(this.gameObject);
            }
        }
    }
}
