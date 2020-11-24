using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    CharacterController controller;
    public float speed = 12f;

    public bool playerInMenu = false;
    public GameObject menuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if(menuCanvas == null)
        {
            menuCanvas = GameObject.FindGameObjectWithTag("PauseMenu");
        }

        menuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInMenu == false)
        {
            MovePlayer();
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeCanvas();
        }
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    public void ChangeCanvas()
    {
        if (menuCanvas.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            SetBools(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            SetBools(true);
        }
    }


    void SetBools(bool _value)
    {
        Cursor.visible = _value;
        menuCanvas.SetActive(_value);
        playerInMenu = _value;
    }
}
