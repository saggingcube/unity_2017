using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEP_MouseMovement : MonoBehaviour
{
    YEP_CharacterInput playerInput;

    
    public float lookAngle;
    public float LookSpeed;

    public float tiltAngle;    
    public float tiltMax = 75f;
    public float tiltMin = 45f;

    public Transform pivot;

    // Use this for initialization
    void Start ()
    {
        playerInput = GetComponent<YEP_CharacterInput>();
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

        lookAngle += x * LookSpeed;

        transform.rotation = Quaternion.Euler(0f, lookAngle, 0);

        tiltAngle -= y * LookSpeed;
        tiltAngle = Mathf.Clamp(tiltAngle, -tiltMax, tiltMax);

        pivot.localRotation = Quaternion.Euler(tiltAngle, 0, 0);
    }
}
