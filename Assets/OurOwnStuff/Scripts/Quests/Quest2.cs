using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest2 : Quest
{
    public Quest2(int _id, int _questSize) : base(_id, _questSize)
    {

    }

    public override void UpdateQuest(string objectivename)
    {
        if (objectivename.Equals("Kødhammer"))
        {
            if (questCounter[1] <= 0)
            {
                questCounter[1]++;
                UpdateText();
                //SoundManager.soundManager.PlaySound();
            }
        }
        else if (objectivename.Equals("Kniv"))
        {
            if (questCounter[0] <= 0)
            {
                questCounter[0]++;
                UpdateText();
                //SoundManager.soundManager.PlaySound();
            }
        }
        else if (objectivename.Equals("BlockMeat"))
        {
            if (questCounter[2] <= 0)
            {
                questCounter[2]++;
                UpdateText();
                //SoundManager.soundManager.PlaySound();
            }
        }
        else if (objectivename.Equals("SliceofMeat"))
        {
            //print("You touched slice of meat with hammer");
            if (questCounter[3] <= 0)
            {
                questCounter[3]++;
                UpdateText();
                //SoundManager.soundManager.PlaySound();
            }
        }
        UpdateText();
        CheckForVictory();
    }

    public override void UpdateText()
    {
        QuestManager.questManager.questText.GetComponent<TextMeshProUGUI>().text = "Saml kniven op " + questCounter[0] + "/" + "1" + "\n"
        + "Saml Kødhammeren op " + questCounter[1] + "/" + "1" + "\n"
        + "Skær et stykke kød " + questCounter[2] + "/" + "1" + "\n"
        + "Bank stykket " + questCounter[3] + "/" + "1";

        //QuestManager.questManager.SetHandQuestText();
    }
    public override void CheckForVictory()
    {
        if (questCounter[0] == 1 && questCounter[1] == 1 && questCounter[2] == 1 && questCounter[3] == 1)
        {
            //print("Won quest 2");
            //Enable video for victory
            QuestManager.questManager.victory.SetActive(true);
        }
    }
}
