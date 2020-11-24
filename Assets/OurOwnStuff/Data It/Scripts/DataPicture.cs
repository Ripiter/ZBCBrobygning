using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataPicture : MonoBehaviour
{

    public GameObject image;
    public GameObject image2;
    public GameObject button;
    public TextMeshProUGUI text;
    public bool isFinished;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Du har mistet internettet, gå hen til væggen og start med at klikke på den røde knap";
    }
    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (!isFinished)
            {
                text.text = "Du har ændret dine firewall indstillinger, det virkede desværre ikke, prøv at genstarste routeren";
                image.SetActive(false);
                button.SetActive(false);
                Instantiate(image2, new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z - 0.6f), Quaternion.identity);
                isFinished = true;
                QuestManager.questManager.GetQuestFromID(5).UpdateQuest("CableSpot");

            }
        }



    }

}
