using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WirePlace : MonoBehaviour
{
    public GameObject prefab;
    public string name;
    public GameObject canvas;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Placere ledningen på væggen";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NameOfObject>() != null)
        {
            if (other.gameObject.GetComponent<NameOfObject>().objectName == name)
            {
                Debug.Log("Wire placed");
                Instantiate(prefab, GetVector(other.gameObject.GetComponent<NameOfObject>().objectName), Quaternion.Euler(new Vector3(90, 90, 0)));
                Destroy(other.gameObject);
                Destroy(gameObject);
                //GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlayer>().ChangePlayerState(true);
                if (other.gameObject.GetComponent<NameOfObject>().objectName == name)
                {
                    canvas.SetActive(true);
                    text.text = "Træk ledning til den rigtige farve";
                }
            }
        }
    }


    public Vector3 GetVector(string objectName)
    {
        switch (objectName)
        {
            case "Wire":
                return new Vector3(transform.position.x, transform.position.y, transform.position.z);
            default:
                break;
        }
        return Vector3.zero;
    }
}
