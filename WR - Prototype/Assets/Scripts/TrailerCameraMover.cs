using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

                if (Input.GetKey(KeyCode.F)) {
                    print("Zooming In");
                    zoomSize -= 0.5f * zoomSpeed * 0.1f;
                } 
                else {
                    zoomSize -= 0.5f * zoomSpeed * Time.deltaTime;
                }
            }

        }
        //Camera Zoom Out
        if (Input.GetKey(KeyCode.M)) {

            if (zoomSize < 3) {
                
                if(Input.GetKey(KeyCode.F)) {
                    print("Zooming Out");
                    zoomSize += 0.5f * zoomSpeed * 0.1f;
                } 
                else {
                    zoomSize += 0.5f * zoomSpeed * Time.deltaTime;
                }
            }
        }
        mainCamera.orthographicSize = zoomSize;

        //RESTART & PAUSE
        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene("TrailerScene");
        }
        if (Input.GetKey(KeyCode.F)) {
            Time.timeScale = 0f;
        }
        if (Input.GetKeyUp(KeyCode.F)) {
            Time.timeScale = 1f;
        }
    }
}

