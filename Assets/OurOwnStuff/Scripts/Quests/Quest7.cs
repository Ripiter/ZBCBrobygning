using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest7 : Quest
{

    public Quest7(int _id, int _questSize) : base(_id, _questSize)
    {

    }

    public override void UpdateQuest(string objectivename)
    {
        if (objectivename == "Coocking")
        {
            if (KitchenManager.instance != null)
            {
                if (questCounter[0] <= KitchenManager.instance.startPlateCount)
                {
                    questCounter[0]++;
                    UpdateText();
                    //SoundManager.soundManager.PlaySound();                    
                }
            }
        }

        CheckForVictory();
    }

    public override void UpdateText()
    {
        QuestManager.questManager.questText.GetComponent<TextMeshProUGUI>().text = "Plate " + questCounter[0] + "/" + KitchenManager.instance.startPlateCount;
    }
    public override void CheckForVictory()
    {
        if (questCounter[0] >= KitchenManager.instance.startPlateCount)
        {
            // You win
            Debug.Log("Win");
        }

    }
}
