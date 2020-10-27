using System.Collections;
using UnityEngine;

public class QuestSixObjective : MonoBehaviour
{
    public string nameOfObject;
    MeshRenderer rend;

    public bool isRunning = false;

    public bool washed = false;

    public float startSmoothness = 1f;

    Quest quest;
    // Start is called before the first frame update
    void Start()
    {
        if (CanAccess())
        {
            rend = GetComponent<MeshRenderer>();
        }
        quest = QuestManager.questManager.GetQuestFromID(6);
        QuestManager.questManager.LoadLevelText(quest.id);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanAccess())
        {
            if (rend.materials[0].GetFloat("_GlossMapScale") <= 0 && washed == false || rend.materials[0].GetFloat("_GlossMapScale") <= -7.450581e-08 && washed == false)
            {
                quest.UpdateQuest("Washed");
                washed = true;
            }
        }


    }

    bool CanAccess()
    {
        if (this.nameOfObject == "Cup" || this.nameOfObject == "Pen" || this.nameOfObject == "Pencil")
            return false;
        
        return true;
    }


    private void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.gameObject.GetComponent<ConnecToBrooom>().objectname.Equals("Broom"))
            {
                if (!isRunning)
                {
                    StartCoroutine(Cleaning());
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message + " In quest six objective(EXPECTED)");
        }


        try
        {
            if (other.gameObject.GetComponent<Garbage>().nameOfObjective.Equals("Can"))
            {
                quest.UpdateQuest("Can");
                Destroy(other.gameObject);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log("<color=red>Error: </color>" + e.Message);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cloth"))
        {
            quest.UpdateQuest("Cleaned");

            this.gameObject.SetActive(false);
        }

        

    }

    private void OnTriggerExit(Collider other)
    {
        if (isRunning)
        {
            StopCoroutine(Cleaning());
        }
    }



    IEnumerator Cleaning()
    {
        if (startSmoothness >= 0)
        {
            rend.materials[0].SetFloat("_GlossMapScale", (startSmoothness - 0.1f));

            startSmoothness = startSmoothness - 0.1f;
        }

        yield return new WaitForSeconds(1);
    }
}
