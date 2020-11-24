using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VPlayer_Toemrer : MonoBehaviour
{
    public VideoPlayer vplayer;
    // Start is called before the first frame update
    void Start()
    {
        vplayer.Play();
        StartCoroutine("Waiting");
    }

    // Update is called once per frame
    void Update()
    {
    }


    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(29);
        vplayer.Stop();
    }
}
