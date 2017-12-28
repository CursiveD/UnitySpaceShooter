using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour 
{

	private GameController gc; 
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
		{
			gc = gameControllerObject.GetComponent<GameController>();
		}
		if(gc == null)
		{
			Debug.Log("Cannot find 'GameController' script");

		}
	}
	

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary") {
			return;
		} 
		else {
			
			Instantiate (explosion, transform.position, transform.rotation);
			if (other.tag == "Player") {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				gc.GameOver();
				gc.AddScore(-scoreValue);
				
			} 
			
				Destroy (other.gameObject);
				Destroy (gameObject);
				gc.AddScore (scoreValue);
			
		
		}
	}
}
