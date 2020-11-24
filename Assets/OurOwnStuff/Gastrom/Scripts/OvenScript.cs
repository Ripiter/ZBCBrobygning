using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenScript : MonoBehaviour
{
    public GameObject light;
    public Transform SpawnPos;
    public GameObject[] coockedPrefabs;
    bool isCoocking = false;

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
        if(collision.gameObject.GetComponentInChildren<QuestSevenObjective>() != null || collision.gameObject.GetComponent<QuestSevenObjective>() != null)
        {
            StartCoocking(collision.gameObject);
        }
    }
    


    void StartCoocking(GameObject obj)
    {
        if(isCoocking == false)
            StartCoroutine(Cook(obj.GetComponent<QuestSevenObjective>().NameOfObject, obj));
    }

    IEnumerator Cook(string objName, GameObject coockedObj)
    {
        isCoocking = true;
        for (int i = 0; i < coockedPrefabs.Length; i++)
        {
            // Check with kichen manager if this item can be coocked
            if(coockedPrefabs[i].GetComponentInChildren<QuestSevenObjective>().NameOfObject == KitchenManager.instance.GetCoockedVersion(objName))
            {
                light.SetActive(true);
                yield return new WaitForSeconds(3f);
                Instantiate(coockedPrefabs[i], SpawnPos.position, Quaternion.identity);
                Destroy(coockedObj);
            }
        }
        isCoocking = false;
        light.SetActive(false);
    }
}
