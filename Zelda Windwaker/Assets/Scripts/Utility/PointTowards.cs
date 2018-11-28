using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraTest: MonoBehaviour
{

    [SerializeField]
    private Transform Player;

    private int MoveSpeed = 0;
    private int MaxDist = 15;
    private int MinDist = 15;




    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Space for optional function
            }

        }
    }
}

