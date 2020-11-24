using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PCButtonScript : MonoBehaviour, IInteract
{
    public GameObject image;
    public GameObject image2;
    public TextMeshProUGUI text;
    public bool isFinished = false;
    public DataRouterButton router;

    public string NameOfButton;
    // Start is called before the first frame update
    void Start()
    {
        InteractManager.instance.AddListener(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
  
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5);
        Instantiate(image2, new Vector3(-9.267f, 1.413f, -13.194f), Quaternion.identity);
        text.text = "Sådan!! du har internet!!";
    }

    public void Interacted(GameObject _object)
    {
        if (_object.GetComponent<InteractScript>().StringValue == NameOfButton)
        {
            if (!isFinished && router.isFinished == true)
            {
                Instantiate(image, new Vector3(-9.711f, 1.395f, -15.895f), Quaternion.identity);

                StartCoroutine(Restart());
                isFinished = true;
                QuestManager.questManager.GetQuestFromID(5).UpdateQuest("CableSpot");
            }
        }
    }
}
