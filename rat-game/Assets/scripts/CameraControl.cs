using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Transform anchor;
	public float horizObl;
	public float vertObl; 
	public float zFromAnchor;
	public float yFromAnchor;
	private Vector3 updatedCameraPosition;

	// Use this for initialization
	void Start () {
		SetObliqueness (horizObl, vertObl);
	}

	// Update is called once per frame
	void Update () {
		updatedCameraPosition = anchor.position + new Vector3 (0, yFromAnchor, zFromAnchor);
		Camera.main.transform.position = updatedCameraPosition;
		Camera.main.transform.LookAt (anchor.position);
	}

	void SetObliqueness(float horizObl, float vertObl) {
		Matrix4x4 mat  = Camera.main.projectionMatrix;
		mat[0, 2] = horizObl;
		mat[1, 2] = vertObl;
		Camera.main.projectionMatrix = mat;
	}
}
