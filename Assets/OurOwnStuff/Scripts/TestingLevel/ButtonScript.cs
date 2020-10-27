using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject slideManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextSlide()
    {
        slideManager.GetComponent<SlideManager>().NextSlide();
    }

    public void PreviousSlide()
    {
        slideManager.GetComponent<SlideManager>().PreviousSlide();
    }
}
