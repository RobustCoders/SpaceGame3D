using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{

	#region Public Properties
		public Transform ExplosionPrefab;
		public AudioClip ExplosionSound;

		public Transform SmallerAsteroidPrefab;
		public int NumberOfAsteroidsToSpawnOnDie;
	#endregion
	
	#region Private Properties
		private bool isAlive = true;

		//private GameManager3D gameManager;

		private float invincibilityTimer = 0.2f;
	#endregion

		void Start ()
		{
				//// Get a reference to the game manager in the scene
				//GameObject go = GameObject.Find ("GameManager3D");
				//if (go != null) gameManager = go.GetComponent<GameManager3D>();
		}

		void Update ()
		{
				this.invincibilityTimer -= Time.deltaTime;
		}

		void OnTriggerEnter (Collider other)
		{
				if (invincibilityTimer > 0f)
						return;

				Debug.Log ("I am an asteroid and I just collided with " + other.name);
				if (other.gameObject.GetComponent<Asteroid> () == null)
						StartCoroutine (_Die ());

				/*
		if (other.transform.GetComponent<Asteroid3D>() != null || other.transform.GetComponent<PlayerShip3D>() != null) {
		
			StartCoroutine(_Die (true));
		} else if (other.transform.GetComponent<PlayerBullet3D>() != null) {
			if (gameManager != null) gameManager.AddScore(this.PointValue);

			StartCoroutine(_Die (true));
		}
		*/

		}

		public void Die ()
		{
				StartCoroutine (_Die ());
		}

		IEnumerator _Die ()
		{
				if (!isAlive)
						yield break;
				isAlive = false;

				AudioSource.PlayClipAtPoint (ExplosionSound, this.transform.position);
				Instantiate (ExplosionPrefab, this.transform.position, Quaternion.identity);

				if (SmallerAsteroidPrefab != null) {
						for (int i = 0; i < NumberOfAsteroidsToSpawnOnDie; i++) {
								Instantiate (SmallerAsteroidPrefab, this.transform.position, Quaternion.identity);
						}
				}

				yield return new WaitForSeconds (0.05f);
		
				Destroy (this.gameObject);
		}
}
