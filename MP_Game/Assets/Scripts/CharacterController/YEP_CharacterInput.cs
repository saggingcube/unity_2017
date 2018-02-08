using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEP_CharacterInput : MonoBehaviour
{

    public float mouseX;
    public float mouseY;
    public float horizontal;
    public float vertical;
    public bool mouse1;
    public bool mouse2; 
	
	
	void Update ()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouse1 = Input.GetButton("Fire1");
        mouse2 = Input.GetButton("Fire2");
    }
}
