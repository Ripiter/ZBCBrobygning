using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DataRouterButton : MonoBehaviour
{
    public GameObject image;
    public GameObject image2;
    public TextMeshProUGUI text;
    public bool isFinished;
    public DataPicture pic;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isFinished && pic.isFinished == true)
            {
                Instantiate(image, new Vector3(-9.81f, 1.395f, -15.895f), Quaternion.identity);
                StartCoroutine(Restart());
                isFinished = true;
                QuestManager.questManager.GetQuestFromID(5).UpdateQuest("CableSpot");

            }
        }
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5);
        Instantiate(image2, new Vector3(-9.76f, 1.395f, -15.895f), Quaternion.identity);
        text.text = "Det virkede desværre ikke, sidste mulighed er at genstarte computeren";
    }
}
