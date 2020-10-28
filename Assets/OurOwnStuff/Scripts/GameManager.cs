using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gamemanager = null;  //Static instance of GameManager which allows it to be accessed by any other script.

    private void Awake()
    {
        //Check if gamemanager already exists
        if (gamemanager == null)

            //if not, set gamemanager to this
            gamemanager = this;

        //If gamemanager already exists and it's not this:
        else if (gamemanager != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            
        }
        //if (Input.GetKey(KeyCode.G))
        //{
        //    SceneManager.LoadScene(0);
        //}
        //if (Input.GetKey(KeyCode.H))
        //{
        //    SceneManager.LoadScene(1);
        //}
        //if (Input.GetKey(KeyCode.J))
        //{
        //    SceneManager.LoadScene(2);
        //}
        //if (Input.GetKey(KeyCode.K))
        //{
        //    SceneManager.LoadScene(3);
        //}
        //if (Input.GetKey(KeyCode.L))
        //{
        //    SceneManager.LoadScene(4);
        //}
        //if (Input.GetKey(KeyCode.B))
        //{
        //    SceneManager.LoadScene(5);
        //}
        //if (Input.GetKey(KeyCode.N))
        //{
        //    SceneManager.LoadScene(6);
        //}
    }
}
