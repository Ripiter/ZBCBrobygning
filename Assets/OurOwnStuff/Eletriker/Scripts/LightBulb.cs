using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlubs : MonoBehaviour
{
    Color[] colors = new Color[] { Color.red, Color.green };
    private int currentColor, lenght;
    Renderer renderer;

    public bool LightBulb = false;
    // Start is called before the first frame update
    void Start()
    {
        currentColor = 0;
        lenght = colors.Length;
        renderer.material.color = colors[currentColor];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                currentColor = (currentColor + 1) % lenght;
                renderer.material.color = colors[currentColor];
            }
        }
    }
}
