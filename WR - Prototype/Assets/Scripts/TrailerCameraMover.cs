using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerCameraMover : MonoBehaviour {

    public float cameraSpeed;
    Camera mainCamera;

    public float zoomSize = 2.5f;
    public float zoomSpeed;

	// Use this for initialization
	void Start () {
        mainCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        //Camera Move Up
        if (Input.GetKey(KeyCode.I)) {
            transform.Translate(transform.up * cameraSpeed, Space.World);
        }
        //Camera Move Down
        if (Input.GetKey(KeyCode.K)) {
            transform.Translate(-transform.up * cameraSpeed, Space.World);
        }
        //Camera Move Left
        if (Input.GetKey(KeyCode.J)) {
            transform.Translate(-transform.right * cameraSpeed, Space.World);
        }
        //Camera Move Right
        if (Input.GetKey(KeyCode.L)) {
            transform.Translate(transform.right * cameraSpeed, Space.World);
        }

        //Camera Zoom In
        if (Input.GetKey(KeyCode.N)) {

            if (zoomSize > 1) {
                zoomSize -= 0.5f * zoomSpeed * Time.deltaTime;
            }
        }
        //Camera Zoom Out
        if (Input.GetKey(KeyCode.M)) {

            if (zoomSize < 3) {
                zoomSize += 0.5f * zoomSpeed * Time.deltaTime;
            }
        }
        mainCamera.orthographicSize = zoomSize;
            
    }
}

