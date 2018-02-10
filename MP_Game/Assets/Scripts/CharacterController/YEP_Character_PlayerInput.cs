using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEP_Character_PlayerInput : MonoBehaviour
{

    public float mouseX;
    public float mouseY;

    public float horizontal;
    public float vertical;
    public bool sprint;

    public bool mouse1;
    public bool mouse2; 
	
	
	void Update ()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        //
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        sprint = Input.GetKeyDown(KeyCode.LeftShift);
        //
        mouse1 = Input.GetKeyDown(KeyCode.Mouse0);
        mouse2 = Input.GetKeyDown(KeyCode.Mouse1);
    }
}
