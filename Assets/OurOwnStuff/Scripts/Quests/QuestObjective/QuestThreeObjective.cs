using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestThreeObjective : MonoBehaviour
{
    public string nameofObjective;
    public GameObject phone;


    public GameObject debugText;
    Quest quest;

    // Start is called before the first frame update
    void Start()
    {
        quest = QuestManager.questManager.GetQuestFromID(3);
        QuestManager.questManager.LoadLevelText(quest.id);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SmartPhone>().nameofObjective == "Smartphone")
        {
            quest.UpdateQuest(nameofObjective);
        }
    }

}
