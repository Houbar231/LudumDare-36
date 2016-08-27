using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    private Vector3 movement;
    public Camera MainCamera;
    public bool Arrows = true;
    public float speed = 1.0f;
    private float movementX, movementY;
	
	// Update is called once per frame
	void Update () {
        if (Arrows)
        {
                movementX = Input.GetAxisRaw("Vertical") * speed;
                movementY = Input.GetAxisRaw("Horizontal") * speed;
                MainCamera.transform.Translate(movementY, movementX, 0);
        }
        else
        {

                movementX = Input.GetAxisRaw("Mouse Y") * speed;
                movementY = Input.GetAxisRaw("Mouse X") * speed;
                MainCamera.transform.Translate(-movementY, -movementX, 0);



        }

	}
}
