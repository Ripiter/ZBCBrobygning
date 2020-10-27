using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestOneObjective : MonoBehaviour
{
    Quest quest;

    // Start is called before the first frame update
    void Start()
    {
        quest = QuestManager.questManager.GetQuestFromID(1);
        QuestManager.questManager.LoadLevelText(quest.id);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
