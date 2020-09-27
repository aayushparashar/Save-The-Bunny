using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

	public static GameManager instace;
	public GameObject gameOverPanel;
	public Text scoretext;
	public Text gameOverText;
	bool gameOver = false;
	public int score;
	void Awake(){
		if (instace == null) {
			instace = this;
		}
		score = 0;

	}
	public void GameOver(){
		gameOverPanel.SetActive (true);
		gameOverText.text = "SCORE: " +  score;
		gameOver = true;
		scoretext.gameObject.SetActive (false);
		GameObject.Find ("EnemySpawn").GetComponent<EnemySpawner> ().StopSpawning ();
	}
	public void IncrementScore(){
		if (!gameOver)
			score += 10;
		scoretext.text = score.ToString();
	}
	public void MainMenu(){
		SceneManager.LoadScene (0);
	}
	public void Restart(){
		SceneManager.LoadScene (1);
	}
}
