using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest3 : Quest
{
    public Quest3(int _id, int _questSize) : base(_id, _questSize)
    {

    }
    
    public override void UpdateQuest(string objectivename)
    {
        if (objectivename.Equals("Vindue"))
        {
            if (questCounter[0] <= 0)
            {
                questCounter[0]++;
                UpdateText();
                //SoundManager.soundManager.PlaySound();
            }
        }
        else if (objectivename.Equals("Lys"))
        {
            if (questCounter[1] <= 0)
            {
                questCounter[1]++;
                UpdateText();
                //SoundManager.soundManager.PlaySound();
            }
        }
        else if (objectivename.Equals("Kaffe"))
        {
            if (questCounter[2] <= 0)
            {
                questCounter[2]++;
                UpdateText();
                //SoundManager.soundManager.PlaySound();
            }
        }
        else if (objectivename.Equals("Alarm"))
        {
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
        QuestManager.questManager.questText.GetComponent<TextMeshProUGUI>().text = "Scan med mobilen QR koderne ved følgende kontrolpunkter: \n" + "\n"
        + "- Vindue " + questCounter[0] + "/" + "1" + "\n"
        + "- Lys " + questCounter[1] + "/" + "1" + "\n"
        + "- Kaffemaskine " + questCounter[2] + "/" + "1" + "\n"
        + "Tænd alarm " + questCounter[3] + "/" + "1";

        QuestManager.questManager.SetHandQuestText();
    }

    public override void CheckForVictory()
    {
        if (questCounter[0] == 1 && questCounter[1] == 1 && questCounter[2] == 1 && questCounter[3] == 1)
        {
            //Enable video for victory
            QuestManager.questManager.victory.SetActive(true);
        }
    }
}
