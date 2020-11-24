using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxCounter : MonoBehaviour
{

    public Text txt;
    public Text objective;
    string task = "Flot. Nu har du lavet din opgave";

    // Use this for initialization
    void Start()
    {

        
    }


   

    public List<GameObject> boxes = new List<GameObject>();
    public int counter = 0;


    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Box")
        {
            if (boxes.Contains(collision.gameObject) ==false)
            {
                boxes.Add(collision.gameObject);
                counter++;
                txt.text = counter + " Box sat ind";
                
                if (counter == 5)
                {
                    txt.text = "" + task;


                }
            }
        }
    }
}