using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string name;
    private Texture2D newSprite;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.sprite = Resources.Load<Sprite>("Menuer\\" + name);
        Debug.Log(name);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
