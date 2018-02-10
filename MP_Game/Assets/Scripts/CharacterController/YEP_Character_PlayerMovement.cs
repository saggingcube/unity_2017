using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEP_Character_PlayerMovement : MonoBehaviour
{
    YEP_Character_PlayerInput playerInput;

    public float movementSpeed;
    public float runSpeed;

    public bool isGrounded;
    RaycastHit hitInfo;

    // Use this for initialization
    void Start ()
    {
        playerInput = GetComponent<YEP_Character_PlayerInput>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GroundCheck();
        HandleGravity();
        HandleMovement();
	}

    void GroundCheck()
    {
        
        if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, 2))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void HandleGravity()
    {
        if(!isGrounded)
        {
            transform.position += Physics.gravity * Time.deltaTime;
        }        
    }

    void HandleMovement()
    {
        transform.Translate(playerInput.horizontal * Time.deltaTime * movementSpeed, 0, playerInput.vertical * Time.deltaTime * movementSpeed);
    }

}
