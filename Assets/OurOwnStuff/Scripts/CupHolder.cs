using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupHolder : MonoBehaviour
{
    public Transform spawnPlace;
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
        if (collision.gameObject.GetComponent<QuestSixObjective>() != null)
        {
            string nameObj = collision.gameObject.GetComponent<QuestSixObjective>().nameOfObject;

            if (nameObj == "Pen" || nameObj == "Pencil")
            {
                GameObject tempObj = Instantiate(collision.gameObject, SpawnPos(), Quaternion.identity);

                // Disable boxcollider so it doesnt interact with the cup
                tempObj.GetComponent<BoxCollider>().enabled = false;
                tempObj.GetComponent<Rigidbody>().isKinematic = true;

                // Makes the instantiated object a child of the cup
                tempObj.transform.parent = transform;
                tempObj.transform.Rotate(Vector3.left, 90f);

                Destroy(collision.gameObject);

                QuestManager.questManager.GetQuestFromID(6).UpdateQuest("PenCup");

            }
        }
    }

    /// <summary>
    /// Gets position on top of the plate
    /// </summary>
    /// <returns></returns>
    Vector3 SpawnPos()
    {
        float x = Random.Range(-0.025f, 0.025f);  //red
        float y = Random.Range(-0.025f, 0.025f);  //green
        float z = Random.Range(0, 0.005f);  //blue
        
        return spawnPlace.position - new Vector3(x, y, z); ;
    }
}
