using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Checker : MonoBehaviour
{
    Renderer renderer;
    public TextMeshProUGUI text;

    GameObject plateHolding;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.GetComponent<Plate>() != null)
        {
            Plate plate = collision.gameObject.GetComponent<Plate>();
            
            if (Completed(plate))
            {
                // Change to green color
                renderer.material.color = new Color(0, 1, 0);

                KitchenManager.instance.orders.RemoveAt(0);
                QuestManager.questManager.GetQuestFromID(7).UpdateQuest("Coocking");
                StartCoroutine(KitchenManager.instance.SpawnNewPlate());

                for (int i = 0; i < plate.objectsOnPlate.Count; i++)
                {
                    Destroy(plate.objectsOnPlate[i]);
                }

                plate.objectsOnPlate.Clear();
                plate.objectsNameOnPlate.Clear();

                Destroy(collision.gameObject);
            }
            else
            {
                // Change to red color
                renderer.material.color = new Color(1, 0, 0);
            }

            StartCoroutine(ChangeColorToNormal());
        }
    }


    /// <summary>
    /// Check if plate have all the ingridients requied to pass
    /// </summary>
    /// <param name="plate"></param>
    /// <returns></returns>
    bool Completed(Plate plate)
    {
        for (int i = 0; i < KitchenManager.instance.requied.Length; i++)
        {
            if (!plate.objectsNameOnPlate.Contains(KitchenManager.instance.requied[i]))
            {
                //  Set text that there is someting missing
                text.text = "Ingredient is missing";

                return false;
            }
        }
        
        if(Infected(plate) == true)
        {
            // Set text that there is infected ingredient
            text.text = "There is a infected food";

            return false;
        }
        else
        {
            return true;
        }
    }

    bool Infected(Plate plate)
    {
        for (int i = 0; i < plate.objectsOnPlate.Count; i++)
        {
            Food food = plate.objectsOnPlate[i].GetComponent<Food>();

            if(food != null)
            {
                if (food.infected == true)
                    return true;                
            }
        }

        return false;
    }

    /// <summary>
    /// Changes color to Default (white)
    /// </summary>
    /// <returns></returns>
    IEnumerator ChangeColorToNormal()
    {
        yield return new WaitForSeconds(2f);
        renderer.material.color = new Color(1f, 1f, 1f);
        text.text = "";
    }

}
