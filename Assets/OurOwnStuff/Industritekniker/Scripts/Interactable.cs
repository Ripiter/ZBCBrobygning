using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class Interactable : MonoBehaviour
{
    public string nameOfInteract;
    public Waypoints movePart1;
    public Waypoints movePart2;
    public Waypoints movePart3;

    public PlaceEmne emne;

    public TextMeshProUGUI text;

    public GameObject videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Sæt emnet der ligger på bordet ind i maskinen";
        videoPlayer.SetActive(false);
    }

    public void InteractWithPlayer()
    {
        if (emne.hasCube)
        {
            text.text = "Vent på maskinen er færdig";
            movePart1.moving = !movePart1.moving;
            movePart2.moving = !movePart2.moving;
            movePart3.moving = !movePart3.moving;

            StartCoroutine(Timer());
        }
    }





    IEnumerator Timer()
    {
        yield return new WaitForSeconds(8f);
        movePart1.moving = !movePart1.moving;
        movePart2.moving = !movePart2.moving;
        movePart3.moving = !movePart3.moving;

        if (emne.hasCube)
        {
            text.text = "Tag det nye emne ud og se filmen på tavlen";
            emne.SpawnCube();
            videoPlayer.SetActive(true);
            
        }

    }



}
