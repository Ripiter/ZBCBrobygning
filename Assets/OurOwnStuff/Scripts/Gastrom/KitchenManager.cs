using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    [HideInInspector]
    public string[] requied;

    [HideInInspector]
    public int startPlateCount;

    public GameObject plate;
    public List<string> orders = new List<string>();
    public TextMeshProUGUI orderText;
    public Transform plateSpawnPoint;
    Plate currentPlate;

    public static KitchenManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        startPlateCount = orders.Count;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewPlate());
        UpdateOrder();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateOrder()
    {
        string temp = "Din nuværende ordrer skal indeholde ";
        bool added = false;

        for (int i = 0; i < requied.Length; i++)
        {
            // Checks all the items missing from the plate
            // If the item is missing at it to the text wall
            if (!currentPlate.objectsNameOnPlate.Contains(requied[i]))
            {
                temp += requied[i] + " ";
                added = true;
            }
        }

        if (added == false)
            orderText.text = "Put den ind i boksen for at tjekke om ordren er korrekt";
        else
            orderText.text = temp;

        QuestManager.questManager.SetHandQuestText(orderText.text);
    }


    /// <summary>
    /// Returns name of the coocked product
    /// (Mainly use for oven)
    /// </summary>
    /// <param name="nameOfObj"></param>
    /// <returns></returns>
    public string GetCoockedVersion(string nameOfObj)
    {
        switch (nameOfObj)
        {
            case "Kød":
                return "Stegt kød";
            case "Skivet kød":
                return "Skivet stegt kød";
            case "Chicken":
                return "Coocked Chicken";

            default:
                return "none";
        }
    }

    /// <summary>
    /// Spawn a plate after 1.5 sec unless its a first plate
    /// </summary>
    /// <returns></returns>
    public IEnumerator SpawnNewPlate()
    {
        if (orders.Count > 0)
        {
            if (currentPlate != null)
                yield return new WaitForSeconds(1.5f);
            GameObject temp = Instantiate(plate, plateSpawnPoint.position, Quaternion.identity);
            currentPlate = temp.GetComponent<Plate>();
            requied = orders[0].Split(',');
            UpdateOrder();
        }
        else
        {
            orderText.text = "Ikke flere ordre idag";
            //QuestManager.questManager.handQuestText.GetComponent<TextMeshProUGUI>().text = orderText.text;
        }
    }

    public bool CanBeAddedToPlate(string _name)
    {
        for (int i = 0; i < requied.Length; i++)
        {
            if (requied[i] == _name)
                return true;
        }
        return false;
    }
}
