using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammerPieces : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LookAtPlayer()
    {
        print("called");
        GameObject _player = GameObject.FindGameObjectWithTag("Player");

        transform.LookAt(_player.transform);
    }
}
