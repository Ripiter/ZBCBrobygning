using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VPlayer2 : MonoBehaviour
{
    public VideoPlayer vplayer;
    // Start is called before the first frame update
    void Start()
    {
        vplayer.Play();
        StartCoroutine("Waiting");
    }


    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(29);
        vplayer.Stop();
    }
}
