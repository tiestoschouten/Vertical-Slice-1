using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    private PointTowards lookAt;

    Vector3 currentRotation;
    private Rigidbody rb;

    void Start () {
        lookAt = gameObject.GetComponent<PointTowards>();
        rb = GetComponent<Rigidbody>();
    }
	

	void Update () {
        //Make Boss Fall Down When Hit 2 Times
        currentRotation = transform.rotation.eulerAngles;
        if (Input.GetKeyDown(KeyCode.P))
        {
            lookAt.isActive = false;
            transform.eulerAngles = new Vector3(0, currentRotation.y, 0);
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            openMouth();
        }
        // --------------------------------------------------



    }

    //To Throw bomb into
    void openMouth()
    {

    }
}
