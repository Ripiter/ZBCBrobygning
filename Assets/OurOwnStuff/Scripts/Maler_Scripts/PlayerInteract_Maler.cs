using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract_Maler : MonoBehaviour
{
    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Interactable movable = hit.collider.GetComponent<Interactable>();
                if (movable != null)
                {

                    movable.InteractWithPlayer();

                }
            }
        }

    }

}