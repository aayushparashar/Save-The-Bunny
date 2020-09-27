using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemy;
	public float xLimit;
	public float spawnRate;

	void SpawnEnemy(){
		float x = Random.Range (-xLimit, xLimit);
		Instantiate(enemy, new Vector2(x, transform.position.y), Quaternion.identity); 
	}
	// Use this for initialization
	void Start () {
		StartSpawning ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void StartSpawning(){
		InvokeRepeating("SpawnEnemy",1f,spawnRate);
	}
	public void StopSpawning(){
		CancelInvoke ("SpawnEnemy");
	}
}
