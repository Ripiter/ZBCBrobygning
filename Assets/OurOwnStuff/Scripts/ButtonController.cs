using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject eventSystem;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("EventSystem") == null)
        {
            Instantiate(eventSystem);
            print("Spawned event system");
        }
    }

    // Update is called once per frame

    public void LeaveGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Resume()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlayer>().ChangeCanvas();
    }
}
