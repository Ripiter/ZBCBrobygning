using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneCollision : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Which scene do we load?
        switch (hit.gameObject.tag)
        {
            case "Vagt":
                SceneManager.LoadScene("Vagt_Scene");
                break;
            case "Slagter":
                SceneManager.LoadScene("Slagter_Scene");
                break;
            case "SOSU":
                SceneManager.LoadScene("SOSU_Scene");
                break;                 
            case "Bager":              
                SceneManager.LoadScene("BagerKonditor_Scene");
                break;                 
            case "Serviceassistent":   
                SceneManager.LoadScene("Serviceassistent_Scene");
                break;                 
            case "DataIT":             
                SceneManager.LoadScene("Data-IT_Scene");
                break;                 
            case "Gastronom":          
                SceneManager.LoadScene("Gastronom_Scene");
                break;                 
            case "Hallway":            
                SceneManager.LoadScene("HallWay_Scene");
                break;
            case "TestRoom":
                SceneManager.LoadScene("TutorialLevel");
                break;
            
            default:
                break;
        }
    }
}
