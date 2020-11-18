using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCButtonScript : MonoBehaviour
{
    public GameObject image;
    public GameObject image2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Instantiate(image, new Vector3(-9.711f, 1.395f, -15.895f), Quaternion.identity);
            Destroy(image);
            StartCoroutine(Restart());

        }
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5);
        Instantiate(image2, new Vector3(-9.267f, 1.413f, -13.194f), Quaternion.identity);
    }
}
