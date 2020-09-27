using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rb;
	float xInput;
	Vector2 newPosition;
	public float speed;
	public float xLimit;

	private void Awake(){
		rb = GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		MovePlayer ();
	}
	private void MovePlayer(){
		xInput = Input.acceleration.x;
		newPosition = transform.position;
		newPosition.x += xInput * speed;
		newPosition.x = Mathf.Clamp (newPosition.x, -xLimit, xLimit);
		rb.MovePosition (newPosition);
	}
}
