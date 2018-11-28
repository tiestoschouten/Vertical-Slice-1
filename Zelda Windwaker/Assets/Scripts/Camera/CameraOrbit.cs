using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour {
    
    private Transform parent;

    private Vector3 localRotation;

    [SerializeField]
    private float mouseSensitivity = 4f;
    [SerializeField]
    private float orbitSpeed = 10f;

    [SerializeField]
    private bool lockOn = false;


	void Start () {
        this.parent = this.transform.parent;
	}
	
	void LateUpdate () {
        // if you press left shift you will lock on
		if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            lockOn = !lockOn;
        }

        if (lockOn == false)
        {
            if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

                if(localRotation.y < -15f)
                {
                    localRotation.y = -15f;
                }
                else if(localRotation.y > 90f)
                {
                    localRotation.y = 90f;
                }
            }
        }

        Quaternion qT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
        this.parent.rotation = Quaternion.Lerp(this.parent.rotation, qT, Time.deltaTime * orbitSpeed);
	}
}
