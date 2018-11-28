<<<<<<< HEAD:Zelda Windwaker/Assets/Scripts/BossController.cs
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossController : MonoBehaviour
{

    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 15;
    int MinDist = 10;




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
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
>>>>>>> master:Zelda Windwaker/Assets/Scripts/Boss/BossController.cs
