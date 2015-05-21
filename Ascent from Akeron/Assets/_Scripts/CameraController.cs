using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	private GameObject player;
	public GameObject mainCamera;
	public Vector3 playerCorrection;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position + playerCorrection;
	}

	// LateUpdate is called once per frame
	void LateUpdate () {
		player = GameObject.FindGameObjectWithTag ("Player");
		mainCamera.transform.position = player.transform.position + offset;
	}
}
