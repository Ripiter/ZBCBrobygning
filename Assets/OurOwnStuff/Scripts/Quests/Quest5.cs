using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest5 : Quest
{
    public Quest5(int _id, int _questSize) : base(_id, _questSize)
    {

    }

    public override void UpdateQuest(string objectivename)
    {
        if (objectivename.Equals("Correct cable"))
        {
            if (questCounter[0] <= 8)
            {
                questCounter[0]++;
                UpdateText();
                if (questCounter[0] >= 8)
                {
                    //SoundManager.soundManager.PlaySound();
                }
            }
        }
        else if (objectivename.Equals("CableSpot"))
        {
            if (questCounter[1] <= 4)
            {
                questCounter[1]++;
                UpdateText();
                //SoundManager.soundManager.PlaySound();
            }
        }
        else if (objectivename.Equals("Correct piece"))
        {
            if (questCounter[2] <= 9)
            {
                questCounter[2]++;
                if (questCounter[2] >= 9)
                {
                    //SoundManager.soundManager.PlaySound();
                }
            }
        }

        CheckForVictory();
    }

    public override void UpdateText()
    {
        /*
        if (questCounter[1] <= 0)
        {
            QuestManager.questManager.questText.GetComponent<Text>().text = "Tilslut routeren til switchen";
        }
        else if (questCounter[1] == 2)
        {
            QuestManager.questManager.questText.GetComponent<Text>().text = "Tilslut Switchen til serveren";
        }
        else if (questCounter[1] >= 4)
        {
            QuestManager.questManager.questText.GetComponent<Text>().text = "Dit netværk køre!";
        }
        */
        QuestManager.questManager.SetHandQuestText();
    }

    public override void CheckForVictory()
    {
        if (questCounter[0] >= 8 && questCounter[1] >= 3 && questCounter[2] >= 9)
        {
            //Enable video for victory
            if(QuestManager.questManager.victory != null)
                base.QuestComplete();
        }
    }
}
