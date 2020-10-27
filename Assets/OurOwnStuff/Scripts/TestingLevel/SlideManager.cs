using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class SlideManager : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject[] controllerButtons;

    public int currentPanel = 0;


    void Start()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }

        panels[currentPanel].SetActive(true);

        HideButtons();

        QuestManager.questManager.LoadLevelText(1);
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Next slide");
            NextSlide();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Prev Slide");
            PreviousSlide();
        }
    }

    public void NextSlide()
    {
        panels[currentPanel].SetActive(false);
        HideButtons();

        currentPanel++;

        if (currentPanel >= panels.Length)
            currentPanel = 0;

        CheckForButton(panels[currentPanel].GetComponent<SlideAssigntedButton>().ButtonValue);
        panels[currentPanel].SetActive(true);
    }


    public void PreviousSlide()
    {
        panels[currentPanel].SetActive(false);
        HideButtons();

        currentPanel--;

        if (currentPanel < 0)
            currentPanel = panels.Length - 1;

        CheckForButton(panels[currentPanel].GetComponent<SlideAssigntedButton>().ButtonValue);
        panels[currentPanel].SetActive(true);
    }

    void CheckForButton(string buttonValue)
    {
        for (int i = 0; i < controllerButtons.Length; i++)
        {
            if (controllerButtons[i].name == buttonValue)
                controllerButtons[i].SetActive(true);
        }
    }

    void HideButtons()
    {
        for (int i = 0; i < controllerButtons.Length; i++)
        {
            controllerButtons[i].SetActive(false);
        }
    }
}