using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    
    public Swap truck;
    public Swap palletJack;
    public Swap mainPlayer;
    public List<GameObject> cameraObjects;
    public GameObject activeCamera;

    // Start is called before the first frame update
    void Start()
    {
        activeCamera = cameraObjects[0];

        for (int i = 0; i < cameraObjects.Count - 1; i++)
            cameraObjects[i].SetActive(false);
        activeCamera.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            


            for (int i = 0; i < cameraObjects.Count - 1; i++)
            {
                if(activeCamera == cameraObjects[i])
                {
                    if(i == cameraObjects.Count - 1)
                    {
                        activeCamera = cameraObjects[0];
                        break;
                    }

                    activeCamera = cameraObjects[++i];
                    activeCamera.SetActive(true);
                    break;
                }

                if(cameraObjects[i] != activeCamera)
                {
                    cameraObjects[i].SetActive(false);
                }
            }

        }
    }

    [System.Serializable]
    public class Swap
    {
        public GameObject Camera;
        public Vehicle vehicle;
        
    }
}
