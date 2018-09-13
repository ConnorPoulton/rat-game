using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour {
	//public facing variables
	public float P_maxAngVelDeg;
	public float P_maxVelocity;
	public float P_rotationSmoothing;
	public Vector3 rotationVector;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		applyVelocity ();
	}


	void applyVelocity(){
		if (Input.GetAxis("Horizontal") != 0){
			Quaternion rotation = Quaternion.Euler (0, (Input.GetAxis ("Horizontal") * P_maxAngVelDeg), 0);
			rotationVector = (rotation * rotationVector).normalized;
		}
		Vector3 projectedPosition = this.transform.position + (rotationVector * P_maxVelocity * Time.deltaTime);
		this.transform.LookAt (projectedPosition);
		this.transform.position = projectedPosition;
	}
}
