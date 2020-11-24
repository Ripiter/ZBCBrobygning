using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckerText : MonoBehaviour
{
    Transform playerPos;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerPos);
    }
}
