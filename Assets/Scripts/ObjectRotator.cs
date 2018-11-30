using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour {

	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		rotationSpeed = Random.Range(0.5f * rotationSpeed, 1.5f * rotationSpeed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(GameManager.instance.inGame) {
			transform.Rotate(new Vector3(0f,0f,rotationSpeed));
		}
	}
}
