using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<NameOfObject>() != null)
        {
            if (col.gameObject.GetComponent<NameOfObject>().objectName == gameObject.GetComponent<NameOfObject>().objectName)
            {
                Instantiate(gameObject, col.gameObject.transform.position, Quaternion.Euler(-90.0f, transform.rotation.y, transform.rotation.z));
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.transform.rotation = col.gameObject.transform.rotation;
                gameObject.transform.localScale = col.gameObject.transform.localScale;
                Destroy(col.gameObject);
                Destroy(gameObject);
                text.text = "Godt gået!";
            }
            else
            {
                text.text = "Forkert";
            }
        }
    }
}
