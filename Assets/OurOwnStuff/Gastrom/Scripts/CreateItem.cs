using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    [SerializeField]
    List<GameObject> currentGameObjectsOnPlate = new List<GameObject>();

    public GameObject[] allPosibleCrafts;
    public Canvas canvas;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateVisibleCrafts()
    {
        
    }

    public void AddedToPlate(GameObject gameObject)
    {

    }

    public void RemovedFromPlate(GameObject gameObject)
    {

    }


}
