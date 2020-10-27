using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Quest
{

    public Quest(int _id, int _questSize)
    {
        id = _id;
        questCounter = new int[_questSize];
    }

    public int[] questCounter;
    public int id;

    public abstract void UpdateQuest(string objectivename);

    public abstract void UpdateText();

    public abstract void CheckForVictory();

    public virtual void QuestComplete()
    {
        //Enable video for victory
        QuestManager.questManager.victory.SetActive(true);
    }
}
