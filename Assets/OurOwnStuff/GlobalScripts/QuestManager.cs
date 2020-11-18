using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//TODO: Refactor completely with fire and question marks.
public class QuestManager : MonoBehaviour
{
    public Dictionary<Quest, bool> quests = new Dictionary<Quest, bool>()
    {
        { new Quest1(1, 1), false }, // Tutorial level
        { new Quest2(2, 4), false }, // Slagter
        { new Quest3(3, 4), false }, // Vagt
        { new Quest4(4, 4), false }, // Sosu
        { new Quest5(5, 3), false }, // Data-IT
        { new Quest6(6, 4), false }, // ServiceAssistant
        { new Quest7(7, 1), false }, // Gastronom
        { new Quest8(8, 1), false }, // Smed
        { new Quest9(9, 1), false }, // Bager
        { new Quest10(10, 2), false },  // Anlægsgartner
        { new Quest11(11, 1), false },  // Ernæringsassistent
        { new Quest12(12, 1), false },  // (Bil) Mekaniker
        { new Quest13(13, 1), false }   // Lager og transport 
    };

    public GameObject questText;

    // Temp variable
    public GameObject handQuestText;
    bool pressed = false;

    public GameObject victory;

    //Static instance of QuestManager which allows it to be accessed by any other script.
    public static QuestManager questManager = null;

    private void Awake()
    {
        //Check if QuestManager already exists
        if (questManager == null)

            //if not, set QuestManager to this
            questManager = this;

        //If QuestManager already exists and it's not this:
        else if (questManager != this)

            //Then destroy this. This enforces our singleton pattern
            //meaning there can only ever be one instance of a QuestManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);


        foreach (var quest in quests)
        {
            for (int i = 0; i < quest.Key.questCounter.Length; i++)
            {
                quest.Key.questCounter[i] = 0;
            }
        }
    }



    void Start()
    {
        
    }

    void Update()
    {
        //if (questText == null)
        //{
        //    if (GameObject.FindGameObjectWithTag("QuestText") != null)
        //    {
        //        questText = GameObject.FindGameObjectWithTag("QuestText");

        //        questText.GetComponent<TextMeshProUGUI>().text = "Placeholder text";
        //    }
        //}

        //if (OVRInput.GetDown(OVRInput.Button.Four) || Input.GetKeyDown(KeyCode.Q))
        //{
        //    if (pressed == false)
        //    {
        //        handQuestText.SetActive(true);
        //        pressed = true;
        //    }
        //    else
        //    {
        //        handQuestText.SetActive(false);
        //        pressed = false;
        //    }
        //}


        if (victory == null)
        {
            if (GameObject.FindGameObjectWithTag("Victory") != null)
            {
                victory = GameObject.FindGameObjectWithTag("Victory");
                victory.SetActive(true);
            }
        }
    }

    public Quest GetQuestFromID(int id)
    {
        foreach (KeyValuePair<Quest, bool> quest in quests)
        {
            if (quest.Key.id == id)
                return quest.Key;
        }

        return null;
    }

    /// <summary>
    /// And load hand quest text
    /// </summary>
    /// <param name="id"></param>
    public void LoadLevelText(int id)
    {
        if (questText == null)
        {
            if (GameObject.FindGameObjectWithTag("QuestText") != null)
            {
                questText = GameObject.FindGameObjectWithTag("QuestText");
                // check if its null later 
                handQuestText = GameObject.FindGameObjectWithTag("HandQuestText");
                //handQuestText.SetActive(false);
                GetQuestFromID(id).UpdateText();
            }
        }
    }

    /// <summary>
    /// If the _text is empty the hand quest text will be set to quest text by deafult
    /// </summary>
    /// <param name="_text"></param>
    public void SetHandQuestText(string _text = "")
    {
        if(_text == "")
        {
            //handQuestText.GetComponent<Text>().text =
            //    questText.GetComponent<Text>().text;
        }
        else
        {
            if(handQuestText != null)
            {

            if (handQuestText.GetComponent<Text>() != null)
                handQuestText.GetComponent<Text>().text = _text;
            else if (handQuestText.GetComponent<TextMeshProUGUI>() != null)
                handQuestText.GetComponent<TextMeshProUGUI>().text = _text;
            }
        }
    }
}