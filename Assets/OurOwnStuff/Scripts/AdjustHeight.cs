using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdjustHeight : MonoBehaviour
{
    public Slider slider;
    public GameObject playerObj;
    public Camera camera;
    public GameObject[] playerHands;
    public TextMeshProUGUI text;    // Start is called before the first frame update
    void Start()
    {
        text.text = "Camera y position: " + camera.transform.localPosition.y;

        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Camera height from ovr player controller " +
                    "Camera y position: " + camera.transform.localPosition.y + "\n" + 
                    "Character controller height "  + playerObj.GetComponent<CharacterController>().height;
        //slider.value = player.transform.localPosition.y;
    }

    public void SlideValueChange(float value)
    {
        playerObj.transform.localScale =  new Vector3(value , value, value);

        for (int i = 0; i < playerHands.Length; i++)
        {
            playerHands[i].transform.localScale = new Vector3(value, value, value);
        }
        //playerObj.transform.localScale.y = new Vector3(value, value, value);

        //float headHeight = camera.transform.localPosition.y;
        //float scale = defaultHeight / headHeight;
        //transform.localScale = Vector3.one * scale;
    }
}
