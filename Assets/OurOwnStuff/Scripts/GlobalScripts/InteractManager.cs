using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    private List<IInteract> interacts = new List<IInteract>();
    public static InteractManager instance = null;

    public Camera mainCamera;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Update is called once per frame
    public void AddListener(IInteract _interact)
    {
        interacts.Add(_interact);
    }

    void Interaction(GameObject _interact)
    {
        foreach (IInteract interact in interacts)
        {
            interact.Interacted(_interact);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                InteractScript interact = hit.collider.GetComponent<InteractScript>();
                if (interact != null)
                {
                    Interaction(hit.collider.gameObject);
                }
            }
        }
    }

}

public interface IInteract
{
    void Interacted(GameObject _object);
}
