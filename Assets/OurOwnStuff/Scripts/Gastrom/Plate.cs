using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour, IPickUp
{
    public string NameOfObject;

    public List<string> objectsNameOnPlate = new List<string>();
    public List<GameObject> objectsOnPlate = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        PickupManager.instance.AddListener(this);
    }

    // Update is called once per frame


    private void OnCollisionEnter(Collision collision)
    {
        if (this.NameOfObject == "Plate")
        {
            if (collision.gameObject.GetComponent<QuestSevenObjective>() != null)
            {
                string objName = collision.gameObject.GetComponent<QuestSevenObjective>().NameOfObject;

                // Check if this if statement can be removed
                //if (objectsNameOnPlate.Contains(objName) == false)
                
                objectsNameOnPlate.Add(objName);
                objectsOnPlate.Add(collision.gameObject);
                
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                collision.transform.SetParent(transform);
                KitchenManager.instance.UpdateOrder();
                
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (this.NameOfObject == "Plate")
        {
            if (collision.gameObject.GetComponent<QuestSevenObjective>() != null)
            {
                string objName = collision.gameObject.GetComponent<QuestSevenObjective>().NameOfObject;

                if (objectsNameOnPlate.Contains(objName) == true)
                {
                    //objectsNameOnPlate.Remove(objName);
                    //objectsOnPlate.Remove(collision.gameObject);

                }
                

                KitchenManager.instance.UpdateOrder();
            }
        }
    }


    public void AddFluid(string fluid)
    {
        if (!objectsNameOnPlate.Contains(fluid))
        {
            objectsNameOnPlate.Add(fluid);
            KitchenManager.instance.UpdateOrder();
        }
    }

    public void PickedUp(GameObject _pickedObject)
    {
        if(_pickedObject.GetComponent<Plate>() != null)
        {
            _pickedObject.GetComponent<Plate>().NameOfObject = "Plate";
            _pickedObject.GetComponent<Plate>().objectsNameOnPlate = objectsNameOnPlate;
            _pickedObject.GetComponent<Plate>().objectsOnPlate = objectsOnPlate;
        }
    }

    public void Droped(GameObject _droped)
    {
        //throw new System.NotImplementedException();
    }
}
