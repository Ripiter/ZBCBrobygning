using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawn : MonoBehaviour
{

    [SerializeField]
    GameObject partPrefab, parentObject;



    [SerializeField]
    [Range(1, 1000)]
    int length = 1;


    [SerializeField]
    float parDistance = 0.105f;


    [SerializeField]
    bool reset, spawn, snapFirst, snapLast;


    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            Spawn();
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Rope"))
            {
                Destroy(tmp);
            }

            reset = false;
        }

        if (spawn)
        {
            Spawn();

            spawn = false;
        }
    }


    public void Spawn()
    {
        int count = (int)(length / parDistance);

        for (int i = 0; i < count; i++)
        {
            GameObject tmp;

            tmp = Instantiate(partPrefab, new Vector3((transform.position.x + Random.Range(0.1f, 0.2f)), transform.position.y + parDistance * (i + 1), transform.position.z), Quaternion.identity, parentObject.transform);
            tmp.transform.eulerAngles = new Vector3(180, 0, 0);


            tmp.name = parentObject.transform.childCount.ToString();

            if (i == 0)
            {
                tmp.tag = "CableFit";
                Destroy(tmp.GetComponent<CharacterJoint>());
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }

            if (i == 18)
            {
                tmp.tag = "CableFit";
            }
        }
    }
}
