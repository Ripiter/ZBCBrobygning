
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageSource : MonoBehaviour
{
    public List<ImageEneringsassistent> imglist = new List<ImageEneringsassistent>();
    public RawImage rawImg;
    public static ImageSource instance;
    public int currentNum;
    void Start()
    {
        //currentNum = GetRandomPlaceFromList();
        //rawImg.texture = imglist[currentNum].img;
    }
    private void Awake()
    {
        //Check if gamemanager already exists
        if (instance == null)

            //if not, set gamemanager to this
            instance = this;

        //If gamemanager already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public ImageEneringsassistent GetRandomPlaceFromList()
    {
        if (imglist.Count == 0)
            print("No more");

        return imglist[Random.Range(0, imglist.Count)];
    }
}

[System.Serializable]
public struct ImageEneringsassistent
{
    public Texture img;
    public string name;
}
