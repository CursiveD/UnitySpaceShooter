using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait = 0;
	public float startWait = 0;
	public float waveWait = 0;
	
	public UnityEngine.UI.Text scoreText;
	public UnityEngine.UI.Text restartText; 
	public UnityEngine.UI.Text gameOverText;
	private int score =0 ;
	
	private bool gameOver = false;
	private bool restart = false;
	void Start ()
	{	
		UpdateScore();
		StartCoroutine(SpawnWaves());
		//restartText.text = gameOverText.text = "";
		restartText.text = "";
		gameOverText.text = "";

	}	

	void Update()
	{
		if(this.restart && Input.GetKeyDown (KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);	
		
			
	    }
	}
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while(gameOver == false)
		{
			for(int i = 0; i< hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRoation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRoation);
				yield return new WaitForSeconds(spawnWait);
				//Debug.Log("End Wave");
				
			}
			
			yield return new WaitForSeconds(waveWait);
			
		}
		if(gameOver == true)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				
			}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore();

	}
	public void GameOver()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
		//Debug.Log("Game Over");
	}
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	

	
}
