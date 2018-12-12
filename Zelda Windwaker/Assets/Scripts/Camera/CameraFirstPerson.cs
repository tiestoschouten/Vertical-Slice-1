using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFirstPerson : MonoBehaviour {

    public bool isFirstPerson; 

	void Update () {
        if (Input.GetMouseButton(1))
        {
            isFirstPerson = true;
        }
        else
        {
            isFirstPerson = false;
        }

    }
}
