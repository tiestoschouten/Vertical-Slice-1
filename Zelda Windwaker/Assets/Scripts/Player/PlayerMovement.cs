using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    // Movement forward = A/W/S/D
    // While standing and pushing button W go forward
    // While standing still and moving A/D go left/right
    // While standing and pushing button S go backwards
    // While going left and right and pushing button W go forward -45/45 degrees (North/East or North/West)
    // While going left and right and pushing button S go backwards -180/ degrees (South/East or South/West)
    // While going W or S and pushing A/D go (North/East or North/West or South/East or South/West)



    private float moveSpeed = 3f;
    private float cameraRotation;
    public GameObject cameraPosition;

    void Update()
    {
        cameraRotation = cameraPosition.transform.rotation.eulerAngles.y;

        // Forwards
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.W))
            {
                Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
            }
        }

        // Backwards
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.S))
            {
                Quaternion q = Quaternion.AngleAxis(cameraRotation - 180, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
            } 
        }

        // Left Forward / Left Backwards / Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            // Left Forward
            if (Input.GetKeyDown(KeyCode.W))
            {
                Quaternion q = Quaternion.AngleAxis(cameraRotation - 45, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
            }
            else
            // Left Backwards
            if (Input.GetKeyDown(KeyCode.S))
            {
                Quaternion q = Quaternion.AngleAxis(cameraRotation - 135, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
            }
            else
            // Left
            if (Input.GetKeyDown(KeyCode.A))
            {
                Quaternion q = Quaternion.AngleAxis(cameraRotation - 90, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
            }
        }
        else
        // Right Forward / Right Backwards / Right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            // Right Forward
            if (Input.GetKeyDown(KeyCode.W))
            {
                Quaternion q = Quaternion.AngleAxis(cameraRotation + 45, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
            }
            else
            // Right Backwards
            if (Input.GetKeyDown(KeyCode.S))
            {
                Quaternion q = Quaternion.AngleAxis(cameraRotation + 135, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
            }
            else
            // Right
            if (Input.GetKeyDown(KeyCode.D))
            {
                Quaternion q = Quaternion.AngleAxis(cameraRotation + 90, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
            } 
        }
    }
}

    
 
