using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WireTask : MonoBehaviour
{

    public List<Color> wireColors = new List<Color>();
    public List<Wire> leftWires = new List<Wire>();
    public List<Wire> rightWires = new List<Wire>();

    public Wire CurrentDraggedWire;
    public Wire CurrentHoveredWire;

    public bool IsTaskCompleted = false;

    private List<Color> availColors;
    private List<int> availLeftIndex;
    private List<int> availRightIndex;


    public GameObject Swtich;
    public GameObject Bulb;
    public GameObject Light;

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        availColors = new List<Color>(wireColors);
        availLeftIndex = new List<int>();
        availRightIndex = new List<int>();
        for (int i = 0; i < leftWires.Count; i++)
        {
            availLeftIndex.Add(i);
        }
        for (int i = 0; i < rightWires.Count; i++)
        {
            availRightIndex.Add(i);
        }

        while (availColors.Count > 0 && availLeftIndex.Count > 0 && availRightIndex.Count > 0)
        {
            Color pickedColor = availColors[Random.Range(0, availColors.Count)];
            int pickedLeftIndex = Random.Range(0, availLeftIndex.Count);
            int pickedRightIndex = Random.Range(0, availRightIndex.Count);

            

            leftWires[availLeftIndex[pickedLeftIndex]].SetColor(pickedColor);
            rightWires[availRightIndex[pickedRightIndex]].SetColor(pickedColor);

            availColors.Remove(pickedColor);
            availLeftIndex.RemoveAt(pickedLeftIndex);
            availRightIndex.RemoveAt(pickedRightIndex);
        }
        
        StartCoroutine(CheckTaskCompletion());
    }


    private IEnumerator CheckTaskCompletion()
    {
        while (!IsTaskCompleted)
        {
            int successfulWires = 0;
            for (int i = 0; i < rightWires.Count; i++)
            {
                if (rightWires[i].IsSuccess)
                {
                    successfulWires++;
                }
            }
            if (successfulWires >= rightWires.Count)
            {
                gameObject.SetActive(false);
                //GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlayer>().ChangePlayerState(false);
                Swtich.GetComponent<Renderer>().material.color = Color.green;
                Bulb.GetComponent<Renderer>().material.color = Color.yellow;
                Light.SetActive(true);
            }
            else
            {

            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
