using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VPlayer : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartVideo");
        StartCoroutine("StopVideo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartVideo()
    {
        yield return new WaitForSeconds(1);
        VideoPlayer.Play();
    }
    private IEnumerator StopVideo()
    {
        yield return new WaitForSeconds(5);
        VideoPlayer.Stop();
    }
}
