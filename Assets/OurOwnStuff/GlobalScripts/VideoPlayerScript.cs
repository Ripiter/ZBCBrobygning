using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    [Tooltip("Dont write .mp4")]
    public string VideoName;


    private VideoPlayer videoPlayer;
    private VideoSource videoSource;

    //Audio
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
    }

    IEnumerator playVideo()
    {
        //Add VideoPlayer to the GameObject
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        //Add AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();

        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;

        videoPlayer.source = VideoSource.Url;
        //We want to play from video clip not from url
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, VideoName + ".mp4");

        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        //Set video To Play then prepare Audio to prevent Buffering
        //videoPlayer.clip = videoToPlay;
        videoPlayer.Prepare();

        //Wait until video is prepared
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }


        //Play Video
        videoPlayer.Play();

        //Play Sound
        audioSource.Play();
    }
}
