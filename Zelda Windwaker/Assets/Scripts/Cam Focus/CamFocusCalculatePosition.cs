using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFocusCalculatePosition : MonoBehaviour {

    [SerializeField]
    private Transform boss;
    [SerializeField]
    private Transform player;

    private Vector3 focusLocation = new Vector3(0,0,0);

    void Update () {
        var combinedLocation = boss.position + player.position;
        focusLocation = combinedLocation / 2;
        this.transform.position = focusLocation;
	}
}
