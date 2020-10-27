using System.Collections.Generic;
using UnityEngine;

public class QuestSevenObjective : MonoBehaviour
{
    public string NameOfObject;
    Quest quest;
    // Start is called before the first frame update
    void Start()
    {
        quest = QuestManager.questManager.GetQuestFromID(7);
        QuestManager.questManager.LoadLevelText(quest.id);

        Renderer renderer = GetComponent<Renderer>();

        if(renderer != null)
        {
            try
            {
                renderer.material.SetFloat(Shader.PropertyToID("_FirstOutlineWidth"), 0);
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }  
}
