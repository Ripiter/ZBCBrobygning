using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetSceneAt(1);
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Menuer\\" + scene.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
