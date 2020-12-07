using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSwap : MonoBehaviour
{
    public List<GameObject> textObjective;
    public GameObject activeText;

    // Start is called before the first frame update
    void Start()
    {
        activeText = textObjective[0];

        for (int i = 0; i < textObjective.Count - 1; i++)
            textObjective[i].SetActive(false);
        activeText.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {



            for (int i = 0; i < textObjective.Count - 1; i++)
            {
                if (activeText == textObjective[i])
                {
                    if (i == textObjective.Count - 1)
                    {
                        activeText = textObjective[0];
                        break;
                    }

                    activeText = textObjective[++i];
                    activeText.SetActive(true);
                    break;
                }

                if (textObjective[i] != activeText)
                {
                    textObjective[i].SetActive(false);
                }
            }

        }
    }

    [System.Serializable]
    public class Swap
    {
        public GameObject Camera;
        public Vehicle vehicle;

    }
}
