using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    public float speed = 1;
	
	void Update () { 
            if(Input.GetMouseButton(2))
                Camera.main.transform.position += (new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"))) * speed;
            else
                Camera.main.transform.position += (new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))) * speed;
        Camera.main.orthographicSize += Camera.main.orthographicSize > 1 || Input.GetAxisRaw("Mouse ScrollWheel") > 0 ?Input.GetAxisRaw("Mouse ScrollWheel") : 0;
    }
}