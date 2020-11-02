using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MouseMovement : MonoBehaviour
{
    [SerializeField]
    public float sensitivity = 5.0f;
    [SerializeField]
    public float smoothing = 2.0f;
    // the chacter is the capsule
    public GameObject character;
    // get the incremental value of mouse moving
    private Vector2 mouseLook;
    // smooth the mouse moving
    private Vector2 smoothV;

    private bool canMove = true;

    public Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponentInParent<Rigidbody>();
        character = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if(canMove)
        {
            if(Input.GetKey(KeyCode.Escape))
            {
                canMove = false;
                Cursor.lockState = CursorLockMode.Confined;
                rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
            }
            // md is mosue delta
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

            // the interpolated float result between the two float values
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

            // incrementally add to the camera look
            mouseLook += smoothV;

            if(mouseLook.y > -70.0f && mouseLook.y < 60.0f)
            {
                transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
                character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

            }

        }
        else if (!canMove && Input.GetKey(KeyCode.Escape))
        {
            canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            
        }

    }
    
}