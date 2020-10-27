using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableScript : MonoBehaviour
{
    public bool isCodingPiece;
    public bool isBottle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LookAtPlayer(Vector3 _look)
    {
        print("called movable");
        GameObject _player = GameObject.FindGameObjectWithTag("Player");

        Vector3 dir = _player.transform.position + transform.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        lookRot.x = 0; lookRot.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(3.0f * Time.maximumDeltaTime));
        //transform.rotation.eulerAngles = -_look;
    }
}
