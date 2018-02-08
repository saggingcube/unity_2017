using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEP_Character_PlayerCamera : MonoBehaviour
{
    YEP_Character_PlayerInput playerInput;

    
    private float yawAngle;
    public float LookSpeed;

    private float pitchAngle;    
    private float pitchMax = 75f;
    private float pitchMin = 45f;

    public Transform pivot;

    // Use this for initialization
    void Start ()
    {
        playerInput = GetComponent<YEP_Character_PlayerInput>();

        yawAngle = 260;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void LateUpdate()
    {
        HandleCameraMovement();
    }

    void HandleCameraMovement()
    {
        float x = playerInput.mouseX;
        float y = playerInput.mouseY;

        //Hopefully I have pitch and yaw worked out... 
        //Will continue to add more camera control options. Just a basic layout of how they should work. 
        //This is also just a test with lateUpdate.  

        //FROM UNITY: 
        //LateUpdate is called after all Update functions have been called. This is useful to order script execution. 
        //For example a follow camera should always be implemented in LateUpdate because it tracks objects that might have moved inside Update.

        //Dealing with Yaw. 
        yawAngle += x * LookSpeed;
        transform.rotation = Quaternion.Euler(0f, yawAngle, 0);

        //Dealing with Pitch.
        pitchAngle -= y * LookSpeed;
        pitchAngle = Mathf.Clamp(pitchAngle, -pitchMax, pitchMin);
        pivot.localRotation = Quaternion.Euler(pitchAngle, 0, 0);
    }
}
