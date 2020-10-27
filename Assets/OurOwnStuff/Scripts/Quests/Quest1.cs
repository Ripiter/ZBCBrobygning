using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest1 : Quest
{
    public Quest1(int _id, int _questSize) : base(_id, _questSize)
    {

    }

    public override void UpdateQuest(string objectivename)
    {
        questCounter[0]++;
        UpdateText();
        CheckForVictory();
    }

    public override void UpdateText()
    {
        //QuestManager.questManager.questText.GetComponent<TextMeshProUGUI>().text = "Placer kuberne på bordet " + questCounter[0];
    }
    public override void CheckForVictory()
    {
        if (questCounter[0] >= 7)
        {
            //Enable video for victory
            QuestManager.questManager.victory.SetActive(true);
        }
    }
}
