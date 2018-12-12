using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTechnique : MonoBehaviour {

    private PlayerMovement lockOn;
    private float dashSpeed = 5.0f;
    private float dashTimer = 0f;
    private float dashCounter;
    private float maxDashTime = 0.5f;
    private bool isDashing = false;

    private Vector3 moveDirection;
    private float currentDashTime;

    private Rigidbody rb;

	void Start () {
        lockOn = gameObject.GetComponent<PlayerMovement>();
        dashCounter = maxDashTime;
        rb = GetComponent<Rigidbody>();
	}

	void Update () {
        // Not locked
        if (lockOn.lockedMovement == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (dashCounter >= maxDashTime && (isDashing == false))
                {
                    dashCounter = dashTimer;
                    isDashing = true;
                }
            }
        }
        // If locked
        if (lockOn.lockedMovement == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))
                {
                    if (dashCounter >= maxDashTime && (isDashing == false))
                    {
                        dashCounter = dashTimer;
                        isDashing = true;
                    }
                }
            }
        }
        // Dashing
        if (isDashing == true)
        {
            // Not locked dashing
            if (lockOn.lockedMovement == false)
            {
                transform.position += transform.forward * dashSpeed * Time.deltaTime;
                dashCounter += Time.deltaTime;
                if (dashCounter <= maxDashTime / 2)
                {
                    this.rb.AddForce(Vector3.up * 10);
                }
                else
                {
                    this.rb.AddForce(Vector3.down * 10);
                }
            }
            // If locked dashing
            if (lockOn.lockedMovement == true)
            {   
                // Dashing left
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position += transform.right * -1 * dashSpeed * Time.deltaTime;
                    dashCounter += Time.deltaTime;
                    if (dashCounter <= maxDashTime / 2)
                    {
                        this.rb.AddForce(Vector3.up * 10);
                    }
                    else
                    {
                        this.rb.AddForce(Vector3.down * 10);
                    }
                }
                // Dashing Right
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += transform.right * dashSpeed * Time.deltaTime;
                    dashCounter += Time.deltaTime;
                    if (dashCounter <= maxDashTime / 2)
                    {
                        this.rb.AddForce(Vector3.up * 10);
                    }
                    else
                    {
                        this.rb.AddForce(Vector3.down * 10);
                    }
                }
            }
        }

        if (dashCounter >= maxDashTime)
        {
            
            isDashing = false;
        }
	}


}

