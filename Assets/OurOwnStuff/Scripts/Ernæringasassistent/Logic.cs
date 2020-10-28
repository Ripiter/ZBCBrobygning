
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    int correctAnswers = 1;
    public TextMeshProUGUI text;
    int newNum;
    int tempNum;
    int count = 1;

    ImageEneringsassistent currentImage;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Træk det rigtige navn på pladen over billedet";
        currentImage = ImageSource.instance.GetRandomPlaceFromList();
        ImageSource.instance.rawImg.texture = currentImage.img;
    }

    // Update is called once per frame
    void Update()
    {
        if (ImageSource.instance.imglist.Count == 0)
        {
            text.text = $"Du fik {correctAnswers} ud af 10";
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ImageSource.instance.rawImg.texture.name)
        {

            Destroy(col.gameObject);

            // Remove old image
            ImageSource.instance.imglist.Remove(currentImage);
            if (ImageSource.instance.imglist.Count > 0)
            {
                // Get new image
                currentImage = ImageSource.instance.GetRandomPlaceFromList();
                ImageSource.instance.rawImg.texture = currentImage.img;
                text.text = "Korrekt svar!";
                correctAnswers++;
            }
        }
        else if (col.gameObject.tag != ImageSource.instance.rawImg.texture.name)
        {
            text.text = "Forkert svar!";
            correctAnswers--;
        }
    }
}
