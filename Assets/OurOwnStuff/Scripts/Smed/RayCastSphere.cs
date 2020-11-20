using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RayCastSphere : MonoBehaviour
{

    public float xSize;
    public float lookDownDistance;
    public GameObject Welder;
    public GameObject Spark;
    public GameObject SmeltCircle;
    public GameObject CircleFolder;
    public GameObject videoPlayer;

    private float maxDistance;
    private RaycastHit[] hits;
    private bool isComplete;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            hits = Physics.SphereCastAll(Welder.transform.position, xSize / 2, -transform.right, lookDownDistance);

            float hitPlate1 = 0f;
            float hitPlate2 = 0f;
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.gameObject.name == "Plate1")
                {
                    hitPlate1 = hits[i].collider.gameObject.transform.position.y;
                }
                if (hits[i].collider.gameObject.name == "Plate2")
                {
                    hitPlate2 = hits[i].collider.gameObject.transform.position.y;
                }
            }
            if (hitPlate1 > 0f && hitPlate2 > 0f)
            {
                GameObject spawnedObject = Instantiate(SmeltCircle, new Vector3(transform.position.x, hitPlate1, transform.position.z - 0.2f), Quaternion.identity);
                spawnedObject.transform.SetParent(CircleFolder.transform);
                if (Spark.activeSelf == false)
                {
                    Spark.SetActive(true);
                }
                if (!isComplete)
                {
                    if (CircleFolder.transform.childCount >= 120)
                    {
                        isComplete = true;
                        videoPlayer.SetActive(true);
                    }
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (Spark.activeSelf == true)
            {
                Spark.SetActive(false);
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    RaycastHit hit;

    //    bool isHit = Physics.SphereCast(Welder.transform.position, xSize / 2, -transform.right, out hit, lookDownDistance);
    //    if (isHit)
    //    {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawRay(Welder.transform.position, -transform.right * hit.distance);
    //        Gizmos.DrawWireSphere(Welder.transform.position + -transform.right * hit.distance, xSize / 2);
    //    }
    //    else
    //    {
    //        Gizmos.color = Color.green;
    //        Gizmos.DrawRay(Welder.transform.position, -transform.right * lookDownDistance);
    //    }
    //}

}
