using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest6 : Quest
{
    public Quest6(int _id, int _questSize) : base(_id, _questSize)
    {

    }

    public override void UpdateQuest(string objectivename)
    {
        if (objectivename.Equals("Washed"))
        {
            if (questCounter[0] <= 1)
            {
                questCounter[0]++;
                UpdateText();
                if (questCounter[0] >= 1)
                {
                    SoundManager.soundManager.PlaySound();
                }
            }
        }

        if (objectivename.Equals("Cleaned"))
        {
            if (questCounter[1] <= 3)
            {
                questCounter[1]++;
                UpdateText();
                if (questCounter[1] >= 3)
                {
                    SoundManager.soundManager.PlaySound();
                }
            }
        }     
        if (objectivename.Equals("Can"))
        {
            if(questCounter[2] < 4)
            {
                questCounter[2]++;
                UpdateText();
                if(questCounter[2] >= 4)
                {
                    SoundManager.soundManager.PlaySound();
                }
            }
        }

        if (objectivename.Equals("PenCup"))
        {
            if (questCounter[3] < 5)
            {
                questCounter[3]++;
                UpdateText();
                if (questCounter[3] >= 5)
                {
                    SoundManager.soundManager.PlaySound();
                }
            }
        }

        CheckForVictory();
    }

    public override void UpdateText()
    {
        if (questCounter[0] <= 0)
        {
            QuestManager.questManager.questText.GetComponent<TextMeshProUGUI>().text = "Vask gulvet hos patient rum #1";
        }
        else if (questCounter[1] < 3)
        {
            QuestManager.questManager.questText.GetComponent<TextMeshProUGUI>().text = "Retsmedicineren har spildt kaffe";
        }
        else if (questCounter[2] < 3)
        {
            QuestManager.questManager.questText.GetComponent<TextMeshProUGUI>().text = "Put skraldet i skraldespanden";
        }
        else if(questCounter[3] < 4)
        {
            QuestManager.questManager.questText.GetComponent<TextMeshProUGUI>().text = "Put blyanterne i koppen";
        }

        QuestManager.questManager.SetHandQuestText();
    }

    public override void CheckForVictory()
    {
        if (questCounter[0] >= 1 && questCounter[1] >= 3 && questCounter[2] >= 4 && questCounter[3] >= 5)
        {
            //Enable video for victory
            QuestManager.questManager.victory.SetActive(true);
        }
    }
}
