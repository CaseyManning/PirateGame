using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {


	GameObject[] ships;
	GameObject[] cities;

	public GameObject camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("left")) {
			camera.transform.position = new Vector3 (camera.transform.position.x - 1, camera.transform.position.y, camera.transform.position.z);
		}
		if (Input.GetKey("right")) {
			camera.transform.position = new Vector3 (camera.transform.position.x + 1, camera.transform.position.y, camera.transform.position.z);
		}
		if (Input.GetKey("up")) {
			camera.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y, camera.transform.position.z + 1);
		}
		if (Input.GetKey("down")) {
			camera.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y, camera.transform.position.z - 1);
		}

	}
}
