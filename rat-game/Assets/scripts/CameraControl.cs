using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	[Tooltip("Oblique projection")]
	public float P_horizObl;
	public float P_vertObl; 
	[Tooltip("The point at which the camera will follow. A normalized Vector local to parent")]
	public Vector3 P_cameraTarget;
	[Tooltip("Scaler for cameraTarget")]
	public float P_camZoom;
	[Tooltip("How sensitive the camera is to changes in parent position")]
	public float P_camSnap;
	[Tooltip("How fast the camera pivots in radians")]
	public float P_camSpeed;

	// Use this for initialization
	void Start () {
		SetObliqueness (P_horizObl, P_vertObl);
	}

	// Update is called once per frame
	void Update () {

	}

	void SetObliqueness(float horizObl, float vertObl) {
		Matrix4x4 mat  = Camera.main.projectionMatrix;
		mat[0, 2] = horizObl;
		mat[1, 2] = vertObl;
		Camera.main.projectionMatrix = mat;
	}
}
