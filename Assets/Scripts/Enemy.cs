using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float rotationSpeed;
	public GameObject dust;

	void Start(){
		TrailRenderer tr = GetComponent<TrailRenderer> ();
		tr.sortingLayerName = "Foreground";
		tr.sortingOrder = 2;
	}

	void FixedUpdate(){
		transform.Rotate(0,0,rotationSpeed);
	}
	private void OnTriggerEnter2D(Collider2D collision){
		//AudioSource audio = GetComponent<AudioSource> ();
		AudioSource[] audio = GetComponents<AudioSource>();
		if (collision.gameObject.tag == "Player") {
			audio [1].PlayOneShot(audio[1].clip);
			Destroy (collision.gameObject);
			GameManager.instace.GameOver ();
		} else if(collision.gameObject.tag=="Ground"){
			audio [0].Play ();
			GameManager.instace.IncrementScore ();
			GameObject dd = Instantiate (dust, transform.position, Quaternion.identity);
			gameObject.SetActive (false);
			Destroy (dd, 2f);
			Destroy (gameObject, 2f);
		}
	}

}
