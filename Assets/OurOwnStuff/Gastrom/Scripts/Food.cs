using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Food : MonoBehaviour
{
    public float infectedValue;
    public bool infected = false;
    public Color colorOfOutLine;
    public GameObject cutPrefab;
    public int canBeCutAmount;

    public bool canBeCut;
    public bool canBePlacedOnPlate = true;

    Renderer renderer;

    Color colorStart;
    Color colorEnd;

    // Start is called before the first frame update
    void Start()
    {
        CheckForRenderer();

        colorStart = new Color(colorOfOutLine.r, colorOfOutLine.g, colorOfOutLine.b, 0.4f);
        colorEnd = new Color(colorOfOutLine.r, colorOfOutLine.g, colorOfOutLine.b, 0.9f);
    }


    float duration = 1.0f;
    // Update is called once per frame
    void Update()
    {
        
        if (infected)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;

            // Test this code later
            // If nessary for more then 1 material

            //for (int i = 0; i < renderer.materials.Length; i++)
            //{
            //    renderer.materials[i].SetColor(Shader.PropertyToID("_FirstOutlineColor"), Color.Lerp(colorStart, colorEnd, lerp));
            //}

            renderer.material.SetColor(Shader.PropertyToID("_FirstOutlineColor"), Color.Lerp(colorStart, colorEnd, lerp));

            if(renderer.material.GetFloat(Shader.PropertyToID("_FirstOutlineWidth")) == 0)
            {
                SetOutLine(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            SetOutLine(true);
        }
        else if (collision.gameObject.CompareTag("Knife"))
        {
            if (canBeCut == false)
                return;

            // Make it a int instead of a list of objects
            if(canBeCutAmount > 0)
            {
                GameObject temp = Instantiate(cutPrefab, transform.position, Quaternion.identity);
                temp.GetComponent<Food>().SetOutLine(this.infected);
                canBeCutAmount--;
            }

            if(canBeCutAmount == 0) 
            {
                Destroy(this.gameObject);
            }
        }        
    }

    public void SetOutLine(bool value)
    {
        CheckForRenderer();
        infected = value;

        if (value == true)
        {
            TurnOnHighLight();
        }
        else
        {
            TurnOffHightLight();
        }
    }


    void TurnOnHighLight()
    {
        renderer.material.SetFloat(Shader.PropertyToID("_FirstOutlineWidth"), infectedValue);
    }

    void TurnOffHightLight()
    {
        renderer.material.SetFloat(Shader.PropertyToID("_FirstOutlineWidth"), 0);
    }

    void CheckForRenderer() {
        renderer = GetComponent<Renderer>();

        if (renderer == null)
            renderer = GetComponentInChildren<Renderer>();
    }
}
