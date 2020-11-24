using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paint"))
        {
            if (renderer.material.color == Color.clear)
            {
                renderer.material.color = other.GetComponent<Renderer>().material.color;
            }
            else
            {
                if (other.GetComponent<Renderer>().material.color == new Color(0,0,0,0))
                {
                    renderer.material.color = Color.clear;
                }
                else
                {
                    AdditiveBlend(other.gameObject);
                }
            }
        }
    }

    void SubtractiveBlend(GameObject _other)
    {
        if (renderer.material.color == Color.clear)
        {
            renderer.material.color = _other.GetComponent<Renderer>().material.color;
        }
        else
        {
            float r = _other.GetComponent<Renderer>().material.color.r;
            float g = _other.GetComponent<Renderer>().material.color.g;
            float b = _other.GetComponent<Renderer>().material.color.b;

            r += renderer.material.color.r;
            g += renderer.material.color.g;
            b += renderer.material.color.b;

            r /= 2;
            g /= 2;
            b /= 2;
            Color color = new Color(r, g, b);

            renderer.material.color = color;
        }
        Destroy(_other.gameObject);
    }

    void AdditiveBlend(GameObject _other)
    {
        float h = 0;
        float s = 0;
        float v = 0;
        //Paint drop
        Color.RGBToHSV(_other.GetComponent<Renderer>().material.color, out h, out s, out v);

        float h2 = 0;
        float s2 = 0;
        float v2 = 0;
        //Paint in bucket
        Color.RGBToHSV(renderer.material.color, out h2, out s2, out v2);
        float d = h2 - h;
        if (h > h2)
        {
            // Swap (a.h, b.h)
            var h3 = h2;
            h2 = h;
            h = h3;

            d = -d;

        }
        Color newColor;
        if (_other.GetComponent<Renderer>().material.color == new Color(0, 0, 0, 1) || _other.GetComponent<Renderer>().material.color == new Color(1, 1, 1, 1))
        {
            float avgS = (s + s2) / 2;
            float avgV = (v + v2) / 2;
            newColor = Color.HSVToRGB(h2, avgS, avgV);
        }
        else
        {
            if (d > 0.5) // 180deg
            {
                h = h + 1; // 360deg
                h = (h + 0.5f * (h2 - h)) % 1; // 360deg
            }
            if (d <= 0.5) // 180deg
            {
                h = h + 0.5f * d;
            }
            float avgS = (s + s2) / 2;
            //float avgV = (v + v2) / 2;

            newColor = Color.HSVToRGB(h, avgS, v2);
        }

        renderer.material.color = newColor;
        Destroy(_other.gameObject);
    }
}
