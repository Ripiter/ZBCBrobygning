using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableScript : MonoBehaviour
{
    public bool isCodingPiece;
    public bool isBottle;
    public bool canRotate = true;

    [Tooltip("Whenever you need to set bool on movable for some reason")]
    public bool isTrue;

    [Tooltip("Override deafault layer of 0 with pick up layer")]
    public bool overrideLayer = true;

    // Start is called before the first frame update
    private void Start()
    {
        if (overrideLayer && gameObject.layer == 0)
        {
            // Set Layer to pick up layer
            gameObject.layer = 9;

        }
    }
}
