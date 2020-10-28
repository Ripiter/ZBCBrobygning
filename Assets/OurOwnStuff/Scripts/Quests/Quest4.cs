using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest4 : Quest
{
    public Quest4(int _id, int _questSize) : base(_id, _questSize)
    {
    }
    

    public override void UpdateQuest(string objectivename)
    {
        if (objectivename.Equals("Klods"))
        {
            if (questCounter[2] < 4)
            {
                questCounter[2]++;
                if (questCounter[2] == 4)
                {
                    //SoundManager.soundManager.PlaySound();
                }
            }
        }
        if (objectivename.Equals("Pillow"))
        {
            if (questCounter[0] <= 0)
            {
                questCounter[0]++;
                UpdateText();
                //SoundManager.soundManager.PlaySound();
            }
        }
        if (objectivename.Equals("Flask"))
        {
            if (questCounter[1] <= 0)
            {
                questCounter[1]++;
                UpdateText();
                //SoundManager.soundManager.PlaySound();
            }
        }
        CheckForVictory();
    }

    public override void UpdateText()
    {
        if (questCounter[0] <= 0)
        {
            QuestManager.questManager.questText.GetComponent<Text>().text = "Jeg ligger ikke så godt";
        }
        else if (questCounter[1] <= 0)
        {
            QuestManager.questManager.questText.GetComponent<Text>().text = "*Host* *Host* \n Jeg hoster så slemt for tiden";
        }
        else if (questCounter[2] < 3)
        {
            QuestManager.questManager.questText.GetComponent<Text>().text = "Kan du lege med mig?";
        }
        //else if (questCounter[0] >= 1 && questCounter[1] >= 1)
        //{
        //    QuestManager.questManager.questText.GetComponent<Text>().text = "Tusind tak for hjælpen";
        //}


        QuestManager.questManager.SetHandQuestText();
    }

    public override void CheckForVictory()
    {
        if (questCounter[0] >= 1 && questCounter[1] >= 1 && questCounter[2] >= 4)
        {
            //Enable video for victory
            QuestManager.questManager.victory.SetActive(true);
        }
    }
}
