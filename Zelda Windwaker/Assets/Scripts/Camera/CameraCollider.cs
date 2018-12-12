using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour {

    [SerializeField]
    private CameraFirstPerson cameraPivot;

    [SerializeField]
    private float minDistance = 1f;
    [SerializeField]
    private float maxDistance = 4f;
    [SerializeField]
    private float smooth = 5f;
    private Vector3 dollyDir;
    private Vector3 dollyDirAdjusted;
    private float distance;

    void Awake ()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    void LateUpdate()
    {

        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;

        if (Physics.Linecast (transform.parent.position, desiredCameraPos, out hit))
        {
            distance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }

        if(!cameraPivot.isFirstPerson)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
        }
        else
        {
            Vector3 target = new Vector3(transform.localPosition.x, 1f, -0.2f);
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * smooth);
        }
    }
}
