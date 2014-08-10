using UnityEngine;
using System.Collections;

public class PrefabGenerator : MonoBehaviour
{

	#region Public Properties
		public Transform PrefabToSpawn;
		public float TimeToSpawn;
	#endregion

	#region Private Properties
		private float timeToSpawnTimer;

		//private GameManager gameManager;
	#endregion

		// Use this for initialization
		void Start ()
		{
				//GameObject go = GameObject.Find ("GameManager");
				//if (go != null) gameManager = go.GetComponent<GameManager>();
		}

		void Update ()
		{
				//if (gameManager != null && gameManager.GameMode == GameMode.Paused) return;

				// Count down the timer and spawn the prefab when we reach 0
				timeToSpawnTimer -= Time.deltaTime;
				if (timeToSpawnTimer < 0f) {
						Instantiate (PrefabToSpawn, this.transform.position, PrefabToSpawn.transform.localRotation);
						timeToSpawnTimer += TimeToSpawn;
				}
		}
}
