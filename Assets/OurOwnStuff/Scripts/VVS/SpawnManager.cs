using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour, IInteract
{
    public GameObject objectToSpawn;
    public void Interacted(GameObject _object)
    {
        Instantiate(objectToSpawn);
    }

    // Start is called before the first frame update
    void Start()
    {
        InteractManager.instance.AddListener(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
