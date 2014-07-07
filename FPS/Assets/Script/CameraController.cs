using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject cam;
    public float mouseSense = 0;
	// Use this for initialization
	void Start () {
        Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
        float rh = Input.GetAxis("Mouse X");
        float rv = Input.GetAxis("Mouse Y");


        Vector3 angles = cam.transform.eulerAngles;
        angles.x -= rv *(1+mouseSense);
        cam.transform.eulerAngles = angles;

        angles = transform.eulerAngles;
        angles.y += rh*(1+mouseSense);
        transform.eulerAngles = angles;
   
	}
}
