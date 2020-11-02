using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource completedsound;
    private AudioClip soundtoplay;

    public static SoundManager soundManager = null;  //Static instance of GameManager which allows it to be accessed by any other script.

    private void Awake()
    {
        //Check if gamemanager already exists
        if (soundManager == null)

            //if not, set gamemanager to this
            soundManager = this;

        //If gamemanager already exists and it's not this:
        else if (soundManager != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);


    }

    public void PlaySound()
    {
        completedsound.Play();
    }
}
