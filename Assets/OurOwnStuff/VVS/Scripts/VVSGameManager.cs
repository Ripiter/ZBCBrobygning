using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VVSGameManager : MonoBehaviour
{
    public static VVSGameManager instance = null;
    public float pipeFixed = 0;
    public float pipePlaced = 0;
    public float sinkPlaced = 0;
    public GameObject Text;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Text.GetComponent<TextMeshProUGUI>().text = "Fiks vandrør " + pipeFixed + "/2";
        if (pipePlaced == 10 && sinkPlaced == 1)
        {
            Text.GetComponent<TextMeshProUGUI>().text = "Godt klaret, du er færdig!";
        }
        else if (pipeFixed == 2)
        {
          
            Text.GetComponent<TextMeshProUGUI>().text = "Placer vandrør " + pipePlaced + "/10 \n Placer vask " + sinkPlaced + "/1";
        }

    }
}
