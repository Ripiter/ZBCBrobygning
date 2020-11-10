using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WinDetector : MonoBehaviour
{

    public GameObject prefab1;
    public GameObject prefab2;
    public VideoPlayer videoPlayer;

    public string needToBe1;
    public string needToBe2;

    bool won1;
    bool won2;
    bool playVideo;


    // Start is called before the first frame update
    void Start()
    {
        won1 = false;
        won2 = false;
        playVideo = false;
    }

    private void FixedUpdate()
    {
        if (!won1)
        {
            foreach (var item in prefab1.GetComponentsInChildren<Transform>())
            {
                if (item.name == needToBe1)
                {
                    won1 = true;
                }
            }
        }
        if (!won2)
        {
            foreach (var item in prefab2.GetComponentsInChildren<Transform>())
            {
                if (item.name == needToBe2)
                {
                    won2 = true;
                }
            }
        }
        if (won1 && won2 && !playVideo)
        {
            Debug.Log("Finished");
            playVideo = true;
            videoPlayer.Play();
        }
    }
}
