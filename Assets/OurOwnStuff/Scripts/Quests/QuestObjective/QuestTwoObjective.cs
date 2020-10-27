using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTwoObjective : MonoBehaviour
{
    public string nameofObjective;

    public GameObject sliceOfMeat;
    Quest quest;
    // Start is called before the first frame update
    void Start()
    {
        quest = QuestManager.questManager.GetQuestFromID(2);
        QuestManager.questManager.LoadLevelText(quest.id);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionExit(Collision collision)
    {
        if (!this.gameObject.CompareTag("Meat") && !this.gameObject.CompareTag("SliceofMeat"))
        {
            quest.UpdateQuest(nameofObjective);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.CompareTag("Knife"))
        {
            if (collision.gameObject.CompareTag("Meat"))
            {
                quest.UpdateQuest(collision.gameObject.GetComponent<QuestTwoObjective>().nameofObjective);
                Instantiate(sliceOfMeat, transform.position, Quaternion.identity);
            }
        }

        if (this.gameObject.CompareTag("Meathammer"))
        {
            if (collision.gameObject.CompareTag("SliceofMeat"))
            {
                quest.UpdateQuest(collision.gameObject.GetComponent<QuestTwoObjective>().nameofObjective);
            }
        }
    }
}
