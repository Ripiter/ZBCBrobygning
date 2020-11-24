using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Recipes : MonoBehaviour
{
    public GameObject player;

    public GameObject Plate;

    public GameObject PopUI;

    public InputField namingField;

    public Transform SpawnPoint;

    List<string> DoneRecipes = new List<string>();

    public GameObject[] food;
    public GameObject[] spawnPoint;

    public GameObject foodParent;

    public TextMeshProUGUI RecipesText;

    public GameObject videoPlayer;

    private void Start()
    {
        StartCoroutine(SpawnFood());

    }
    public void AddRecipes() 
    {
        DoneRecipes.Add(namingField.text);

        RecipesText.text = "";

        for (int i = 0; i < DoneRecipes.Count; i++)
        {
            RecipesText.text += "- " + DoneRecipes[i] + "\r\n";
        }

        namingField.text = "";
        PopUI.SetActive(false);
        player.GetComponent<MovementPlayer>().playerInMenu = false;
        Cursor.lockState = CursorLockMode.Locked;

        videoPlayer.SetActive(true);
        StartCoroutine(SpawnFood());
    }

    public void ActiveUI() 
    {
        player.GetComponent<MovementPlayer>().playerInMenu = true;
        PopUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void SpawnPlate() 
    {
        Instantiate(Plate,SpawnPoint.position,Plate.transform.rotation);
    }


    IEnumerator SpawnFood() 
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.2f);
            for (int j = 0; j < food.Length; j++)
            {
                GameObject temp = Instantiate(food[j], spawnPoint[j].transform.position, Quaternion.identity, foodParent.transform);
            }
        }
        
    }
        
    void Update()
    {
            
    }

}
