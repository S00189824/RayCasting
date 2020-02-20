using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAround : MonoBehaviour
{

    public Transform LookAtTarget;
    float mouseX, mouseY;
    public float rotationspeed = 5;
    public bool ShouldInvert = false;
    bool cameramoved;

	// Use this for initialization
	void Update ()
    {
		if(Input.GetMouseButton(1))
        {
            cameramoved = true;
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
        }
        else
        {
            cameramoved = false;
        }

        if(ShouldInvert)
        {
            mouseY *= -1;
        }

        if(cameramoved)
        {
            transform.RotateAround(LookAtTarget.position, Vector3.up, mouseX * rotationspeed);
            transform.RotateAround(LookAtTarget.position, Vector3.right, mouseY * rotationspeed);
        }

        transform.LookAt(LookAtTarget);
	}
}
