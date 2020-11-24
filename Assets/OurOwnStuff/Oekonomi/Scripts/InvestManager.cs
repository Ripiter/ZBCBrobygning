using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvestManager : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    public int firedCounter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (firedCounter == 8)
        {
            taskText.text = "Gode invisteringer! du har bestået!";
            StartCoroutine("Waiting");
        }
    }

    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
