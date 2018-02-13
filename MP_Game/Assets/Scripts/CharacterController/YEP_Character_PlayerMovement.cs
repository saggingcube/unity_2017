using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEP_Character_PlayerMovement : MonoBehaviour
{
    YEP_Character_PlayerInput playerInput;

    public float movementSpeed;
    public float runSpeed;

    public float velocity;

    private Vector3 previousPos;
    public Vector3 forwardPos;

    private Vector2 _input;

    public bool isGrounded;
    public bool isSprinting;
    public bool canJump;

    RaycastHit hitInfo;
    CapsuleCollider capsuleController;
    public LayerMask _ground;
    public float _height;


    public float maxAngle = 120f;
    public float _angle;
    public float groundAngle;

    // Use this for initialization
    void Start ()
    {
        playerInput = GetComponent<YEP_Character_PlayerInput>();
        capsuleController = GetComponent<CapsuleCollider>();
        _height = capsuleController.height;
	}
	
	// Update is called once per frame
	void Update ()
    {
        GroundCheck();
        HandleGravity();
        CalculateForward();
        HandleMovement();        
        CalculateGroundAngle();
	}

    void GroundCheck()
    {
        if (Physics.SphereCast(transform.position, capsuleController.radius, Vector3.down, out hitInfo, capsuleController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
        //if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, 1, _ground))
        //{
        //    isGrounded = true;
        //}
        //else
        //{
        //    isGrounded = false;
        //}
    }

    void HandleGravity()
    {
        if(!isGrounded && !canJump)
        {
            transform.position += Physics.gravity * Time.deltaTime;
        }        
    }

    void HandleMovement()
    {
        isSprinting = playerInput.sprint;
        canJump = playerInput.jump;

        velocity = ((transform.position - previousPos).magnitude) / Time.deltaTime;
        previousPos = transform.position;

        _input = new Vector2(playerInput.vertical, playerInput.horizontal);

        if(_input.sqrMagnitude > 1 )
        {
            _input.Normalize();
        }

        Vector3 desiredMove = forwardPos * _input.x + transform.right * _input.y;

       
        
        if(!isSprinting)
        {
            //transform.Translate(playerInput.horizontal * Time.deltaTime * movementSpeed, 0, playerInput.vertical * Time.deltaTime * movementSpeed);
            transform.position += desiredMove * movementSpeed * Time.deltaTime;
            
            //Show normal direction
            Debug.DrawLine(transform.position, transform.position + forwardPos * _height, Color.blue);
        }
        else
        {
            //transform.Translate(playerInput.horizontal * Time.deltaTime * runSpeed, 0, playerInput.vertical * Time.deltaTime * runSpeed);

            transform.position += desiredMove * runSpeed * Time.deltaTime;
        }       
        
    }

    void CalculateForward()
    {
        if(!isGrounded)
        {
            forwardPos = transform.forward;
            return;
        }

        forwardPos = Vector3.Cross(hitInfo.normal, -transform.right);
    }

    void CalculateGroundAngle()
    {
        if(!isGrounded)
        {
            groundAngle = 90;
            return;
        }

        groundAngle = Vector3.Angle(hitInfo.normal, transform.forward);
    }

    private void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Label(new Rect(0, 0, 400, 100), "Velocity: " + Mathf.Round(velocity * 100) / 100);
        GUI.Label(new Rect(0, 15, 400, 100), "Sprinting: " + isSprinting);
        GUI.Label(new Rect(0, 30, 400, 100), "Grounded: " + isGrounded);
    }

}
