using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{


    public GameObject cookingEffect;

    List<GameObject> CookingObjs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<NameOfObject>() != null) 
        {
            if (collision.gameObject.GetComponent<Ingredients>() != null) 
            {


                CookingObjs.Add(collision.gameObject);
                int index = CookingObjs.Count - 1;
                StartCoroutine(Cooker(index));

            }
            
        }
    }

    IEnumerator Cooker(int index) 
    {
        GameObject temp = Instantiate(cookingEffect,CookingObjs[index].transform.position,Quaternion.identity, CookingObjs[index].transform.parent);
        int time = CookingObjs[index].GetComponent<Ingredients>().CookingTime;
        yield return new WaitForSeconds(time);
        CookingObjs[index].GetComponent<Ingredients>().Cook();
        Destroy(temp);
    }
}
