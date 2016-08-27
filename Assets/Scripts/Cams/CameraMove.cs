using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    public float speed = 1;
	
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

	void Update () { 
            if(Input.GetMouseButton(2))
                Camera.main.transform.position += (new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"))) * speed;
            else
                Camera.main.transform.position += (new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))) * speed;
        Camera.main.orthographicSize += Camera.main.orthographicSize > 1 || Input.GetAxisRaw("Mouse ScrollWheel") > 0 ?Input.GetAxisRaw("Mouse ScrollWheel") : 0;
    }
}
