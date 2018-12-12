using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 3f;
    private float cameraRotation;
    public GameObject cameraPosition;
    private bool leftMovement = true; private bool rightMovement = true; private bool forwardMovement = true; private bool backwardMovement = true;
    private bool leftCorner = true; private bool rightCorner = true;
    private bool cornerMovement = false;
    [SerializeField]
    public bool lockedMovement = false;

    void Update()
    {
        cameraRotation = cameraPosition.transform.rotation.eulerAngles.y;

            // Going Forward
            if (forwardMovement == true)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    backwardMovement = false; leftMovement = false; rightMovement = false;  

                    if (Input.GetKey(KeyCode.W) && (cornerMovement == false))
                    {
                       transform.position += transform.forward * moveSpeed * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                    }
                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    forwardMovement = true; backwardMovement = true; leftMovement = true; rightMovement = true;
                }
            }
            // Going Backwards
            if (backwardMovement == true)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    forwardMovement = false; leftMovement = false; rightMovement = false;
                    
                    if (lockedMovement == false && Input.GetKey(KeyCode.S) && (cornerMovement == false))
                    {
                        transform.position += transform.forward * moveSpeed * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation - 180, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);

                }
                    if (lockedMovement == true && Input.GetKey(KeyCode.S) && (cornerMovement == false))
                    {
                        transform.position += transform.forward * -1 * moveSpeed * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                }
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    forwardMovement = true; backwardMovement = true; leftMovement = true; rightMovement = true;
                }
            }
            // Going Left
            if (leftMovement == true)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    forwardMovement = false; backwardMovement = false; rightMovement = false;

                if (lockedMovement == false && Input.GetKey(KeyCode.A) && (cornerMovement == false))
                {
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    Quaternion q = Quaternion.AngleAxis(cameraRotation - 90, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);

                }
                if (lockedMovement == true && Input.GetKey(KeyCode.A) && (cornerMovement == false))
                {
                    transform.position += transform.right * -1 * moveSpeed * Time.deltaTime;
                    Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                }

            }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    forwardMovement = true; backwardMovement = true; leftMovement = true; rightMovement = true;
                }
            }
            // Going Right
            if (rightMovement == true)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    forwardMovement = false; backwardMovement = false; leftMovement = false;

                if (lockedMovement == false && Input.GetKey(KeyCode.D) && (cornerMovement == false))
                {
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    Quaternion q = Quaternion.AngleAxis(cameraRotation + 90, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);

                }
                if (lockedMovement == true && Input.GetKey(KeyCode.D) && (cornerMovement == false))
                {
                    transform.position += transform.right * moveSpeed * Time.deltaTime;
                    Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                }
            }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    forwardMovement = true; backwardMovement = true; leftMovement = true; rightMovement = true;
                }
            }

            // Going Right Up / Right Down
            if (rightCorner == true)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    leftCorner = false;
                    // Right Up
                    if (Input.GetKey(KeyCode.W))
                    {
                        cornerMovement = true;
                    if (lockedMovement == false)
                    {
                        transform.position += transform.forward * moveSpeed * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation + 45, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                    }
                    if (lockedMovement == true)
                    {
                        transform.position += ((transform.right * moveSpeed * Time.deltaTime) + (transform.forward * moveSpeed * Time.deltaTime)) / 2;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                    }
                    }
                    // Right Down
                    if (Input.GetKey(KeyCode.S))
                    {
                    cornerMovement = true;
                        if (lockedMovement == false) {
                        transform.position += transform.forward * moveSpeed * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation + 135, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                        }
                        if (lockedMovement == true)
                        {
                        transform.position += ((transform.right * moveSpeed * Time.deltaTime) + (transform.forward * moveSpeed * Time.deltaTime * -1)) / 2;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                        }
                    }
                }
            if ((Input.GetKeyUp(KeyCode.D)) || (Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S)))
            {
                cornerMovement = false;
                leftCorner = true;
            }
        }

            // Going Left Up / Left Down
            if (leftCorner == true)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    rightCorner = false;
                    // Left Up
                    if (Input.GetKey(KeyCode.W))
                    {
                        cornerMovement = true;
                    if (lockedMovement == false)
                    {
                        transform.position += transform.forward * moveSpeed * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation - 45, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                    }
                    if (lockedMovement == true)
                    {
                        transform.position += ((transform.right * moveSpeed * Time.deltaTime * -1) + (transform.forward * moveSpeed * Time.deltaTime)) / 2;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                    }
                } 
                    // Right Up
                    if (Input.GetKey(KeyCode.S))
                    {
                        cornerMovement = true;
                    if (lockedMovement == false)
                    {
                        transform.position += transform.forward * moveSpeed * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation - 135, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                    }
                    if (lockedMovement == true)
                    {
                        transform.position += ((transform.right * moveSpeed * Time.deltaTime * -1) + (transform.forward * moveSpeed * Time.deltaTime * -1)) / 2;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                    }
                }
            }
                if ((Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S)))
                {
                    cornerMovement = false;
                    rightCorner = true;
                }
            }
    }
}

    
 
