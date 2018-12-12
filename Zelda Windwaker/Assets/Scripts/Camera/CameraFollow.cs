using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    
    [SerializeField]
    private GameObject camFocus;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject camera;

    [SerializeField]
    private float smoothFollow;

    [SerializeField]
    private float smoothRotate;

    void Update () {
        Cursor.lockState = CursorLockMode.Locked;
        if (camera.GetComponent<CameraOrbit>().lockOn == true)
        {
            target = camFocus;
        }
        else
        {
            target = player;
        }

        transform.position = Vector3.Lerp(transform.position, target.transform.position, smoothFollow);
        if (camera.GetComponent<CameraOrbit>().lockOn == true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, smoothRotate);
        }
    }
}
