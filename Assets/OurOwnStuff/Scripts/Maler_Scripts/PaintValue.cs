using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintValue : MonoBehaviour
{
    public GameObject targetColor;
    float h, s, v;
    Color color;
    public Text targetText;
    // Start is called before the first frame update
    void Start()
    {
        color = targetColor.GetComponent<Renderer>().material.color;
        targetText.text = "Farven har værdien: \n" + OutputColorValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetColor.GetComponent<Renderer>().material.color != color)
        {
            color = targetColor.GetComponent<Renderer>().material.color;
            targetText.text = "Farven har værdierne: \n" + OutputColorValues();
        }
    }

    string OutputColorValues()
    {
        Color.RGBToHSV(color, out h, out s, out v);
        return h + ",\n" + s + ",\n" + v;
    }
}
