﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    private float playerDistance;
	
	void Update () {
        transform.position = new Vector3(target.transform.position.x, 
                                         target.transform.position.y,
                                         target.transform.position.z - playerDistance);
    }
}
