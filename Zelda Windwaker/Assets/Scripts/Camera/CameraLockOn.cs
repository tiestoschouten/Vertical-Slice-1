using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLockOn : MonoBehaviour {

    [SerializeField]
    private GameObject camera;

    void Update () {
        if (camera.GetComponent<CameraOrbit>().lockOn == true)
        {

        }
    }
}
