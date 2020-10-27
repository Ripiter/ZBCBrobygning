using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestFourObjective : MonoBehaviour
{
    public string nameofObjective;
    Quest quest;
    // Start is called before the first frame update
    void Start()
    {
        quest = QuestManager.questManager.GetQuestFromID(4);
        QuestManager.questManager.LoadLevelText(quest.id);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (nameofObjective.Equals("Flask"))
        {
            if (other.gameObject.CompareTag("Diva"))
            {
                quest.UpdateQuest("Flask");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (nameofObjective.Equals("Pillow"))
        {
            if (collision.gameObject.CompareTag("Hand"))
            {
                quest.UpdateQuest("Pillow");
            }
        }
        else if (nameofObjective.Equals("Klods"))
        {
            if (collision.gameObject.CompareTag("Klods"))
            {
                quest.UpdateQuest("Klods");
            }
        }
    }
}
