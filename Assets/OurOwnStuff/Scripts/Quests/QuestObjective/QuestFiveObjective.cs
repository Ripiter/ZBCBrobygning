using UnityEngine;

public class QuestFiveObjective : MonoBehaviour
{
    public string nameofObjective;

    public GameObject cable;

    public Vector3 offset;

    public GameObject debugtext;

    private Rigidbody rb;

    public Transform parentTransform;


    Quest quest;
    // Start is called before the first frame update
    void Start()
    {
        quest = QuestManager.questManager.GetQuestFromID(5);
        QuestManager.questManager.LoadLevelText(quest.id);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Cable>() == true)
        {
            if (other.gameObject.GetComponent<Cable>().nameofObjective.Equals(nameofObjective))
            {
                Instantiate(cable, offset, Quaternion.identity);
                Destroy(other.gameObject);

                quest.UpdateQuest("Correct cable");
            }

            if (other.gameObject.GetComponent<Cable>().nameofObjective.Equals("CableSpot") && gameObject.CompareTag("CableFit"))
            {
                quest.UpdateQuest("CableSpot");
                rb.isKinematic = true;
            }
        }
        else if (other.gameObject.GetComponent<Codepiece>() != null)
        {
            if (other.gameObject.GetComponent<Codepiece>().nameofObjective.Equals(nameofObjective))
            {
                Instantiate(cable, parentTransform);
                Destroy(other.gameObject);
                quest.UpdateQuest("Correct piece");
            }
        }
    }
}
