using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour {
	//public facing variables
	public float maxVelocity;
	public float P_xRotAccelDeg;
	private float xRotAccelDelta;
	public float P_xRotVelocDegMax;
	private float xRotVeloc;
	private Vector3 locationVector; 

	// Use this for initialization
	void Start () {
		locationVector = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		applyVelocity ();
	}


	void applyVelocity(){
		//Update rotation
		float inputXAxis = Input.GetAxis("Horizontal");
		Debug.Log(inputXAxis);
		xRotAccelDelta = (P_xRotAccelDeg) * Time.deltaTime;
		xRotVeloc = Mathf.Lerp (-inputXAxis, inputXAxis, xRotAccelDelta);
		Quaternion quatRotation = Quaternion.Euler (xRotVeloc,0,0);
		//update position
		this.transform.position += ((quatRotation * Vector3.forward) * maxVelocity);//order matters here! 
		//change rotation of model
		float step = xRotVeloc * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards(transform.rotation, quatRotation, step);
	}
}
