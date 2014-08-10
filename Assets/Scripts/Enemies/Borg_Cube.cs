using UnityEngine;
using System.Collections;

public class Borg_Cube : MonoBehaviour
{
	#region Public Properties
		public Transform ExplosionPrefab;
		public AudioClip ExplosionSound;
	#endregion

	#region Private Properties
		private int rotationSpeed;
		
		private float HP;
		private int maxHP;
		private bool isAlive;

		private bool isRegenerating;
		private float recoveryRate;
	#endregion

		void Start ()
		{
				rotationSpeed = 10;

				HP = maxHP = 1000;
				isAlive = true;

				isRegenerating = false;
				recoveryRate = 20f;
		}
	

		void Update ()
		{
				this.transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
			
				if (HP < 0)
						StartCoroutine (_Die ());
				//Debug.Log ("HP = " + HP);

				regenerate ();
				

		}

		void OnTriggerEnter (Collider other)
		{
				TakeDamage ();


		}


		void TakeDamage ()
		{
				HP -= (Random.Range (10, 20) + 20);

		}

		void regenerate ()
		{
				if (HP < (maxHP * .6))		
						isRegenerating = true;
				else
						isRegenerating = false;

				if (isRegenerating) {
						if (HP < maxHP) {
								HP += recoveryRate * Time.deltaTime;
								if (HP > maxHP)
										HP = maxHP;
						}
				}
		}

		IEnumerator _Die ()
		{
				if (!isAlive)
						yield break;
			
				isAlive = false;
				AudioSource.PlayClipAtPoint (ExplosionSound, this.transform.position);
				Instantiate (ExplosionPrefab, this.transform.position, Quaternion.identity);
				yield return new WaitForSeconds (.05f);
				Destroy (this.gameObject);

		}
}

