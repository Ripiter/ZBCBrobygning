using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPicture : MonoBehaviour
{
   
    public GameObject image;
    public GameObject image2;
    public GameObject button;

    private void OnMouseOver()
    {
        Debug.Log("Hej");
        if (Input.GetMouseButtonDown(0))
        {
            image.SetActive(false);
            button.SetActive(false);
            Instantiate(image2, new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z - 0.6f), Quaternion.identity);
            
        }
       
   

    }
  
}
