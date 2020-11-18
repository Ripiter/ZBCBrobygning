using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RayCastSphere : MonoBehaviour
{

    public float xSize;
    public float lookDistance;
    public GameObject SmeltCircle;
    public GameObject CircleFolder;
    public GameObject videoPlayer;

    private float maxDistance;
    private RaycastHit[] hits;
    private bool isComplete;

    // Start is called before the first frame update
    void Start()
    {
        maxDistance = lookDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            hits = Physics.SphereCastAll(transform.position, xSize / 2, transform.forward, maxDistance);
            //bool isHit = Physics.SphereCastAll(transform.position, xSize / 2, maxDistance);

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
                if (!isComplete)
                {
                    if (CircleFolder.transform.childCount >= 200)
                    {
                        isComplete = true;
                        videoPlayer.SetActive(true);
                    }
                }
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    float maxDistance = lookDistance;
    //    RaycastHit hit;

    //    bool isHit = Physics.SphereCast(transform.position, xSize / 2, transform.forward, out hit, maxDistance);
    //    if (isHit)
    //    {      
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            //Debug.Log("Success");
    //        }
    //        else
    //        {
    //            //Debug.Log("Failed");
    //        }
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
    //        Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, xSize / 2);
    //    }
    //    else
    //    {
    //        Gizmos.color = Color.green;
    //        Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
    //    }
    //}

}
