using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{

    public static VibrationManager vibrationmanager = null;  //Static instance of GameManager which allows it to be accessed by any other script.

    private void Awake()
    {
        //Check if gamemanager already exists
        if (vibrationmanager == null)

            //if not, set gamemanager to this
            vibrationmanager = this;

        //If gamemanager already exists and it's not this:
        else if (vibrationmanager != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {

    }


}
