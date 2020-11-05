using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmeltArea : MonoBehaviour
{

    public GameObject[] gameObjects;

    private List<Collider> colliders = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool CheckObject(string name)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i].name == name)
            {
                return true;
            }
        }
        return false;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (!CheckObject(other.name))
        {
            colliders.Add(other);
        }
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Debug.Log(gameObjects[i].name);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (CheckObject(other.name))
        {
            colliders.Remove(other);
        }
    }

}
