using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BakeBread : MonoBehaviour
{
    public Material mat;
   
   
    Color brown = new Color(0.7830189f, 0.405858f, 0);
    // Start is called before the first frame update
    void Start()
    {
        mat.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator OnCollisionEnter(Collision collision)
    {
        
            if (collision.gameObject.GetComponent<NameOfObject>() != null)
            {
                if (collision.gameObject.GetComponent<NameOfObject>().objectName == "Boller")
                {

                yield return new WaitForSeconds(2);
                    mat.color = brown;
                   




            }
        }
        
    }


}
