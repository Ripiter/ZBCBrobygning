using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalColor : MonoBehaviour
{
    Renderer renderer;
    public GameObject checkCfrom;
    Renderer otherRender;
    Color color;
    public Text winAnnounce;
    int correctCount;
    float threshold = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        SetColor();
        otherRender = checkCfrom.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckColors();
        winAnnounce.text = "Du har blandet " + correctCount + " ud af 3 farver";
        if (correctCount == 3)
        {
        winAnnounce.text = "Du har blandet alle farverne rigtigt. Du er nu færdig.";

        }
    }
    bool TheSameColor(float h, float s, float v)
    {

        if (!(h <= threshold && h >= -threshold))
        {
            return false;
        }
        if (!(s <= threshold && s >= -threshold))
        {
            return false;
        }
        if (!(v <= threshold && v >= -threshold))
        {
            return false;
        }
        return true;


    }
    void CheckColors()
    {
        float h1, s1, v1, h2, s2, v2;
        //Væg farve
        Color.RGBToHSV(color, out h1, out s1, out v1);
        //Spand farve
        Color.RGBToHSV(otherRender.material.color, out h2, out s2, out v2);
        if (TheSameColor(h1 - h2, s1 - s2, v1 - v2) && otherRender.material.color != Color.clear)
        {
            Debug.Log((h1-h2) + ", " + (s1-s2) + ", " + (v1-v2));
            correctCount++;

            Debug.Log("h1 " + h1 + " h2 " + h2);
            Debug.Log("s1 " + s1 + " s2 " + s2);
            Debug.Log("v1 " + v1 + " v2 " + v2);
            SetColor();

        }

    }

    void SetColor()
    {
        color = Random.ColorHSV();
        renderer.material.color = color;
    }
}
