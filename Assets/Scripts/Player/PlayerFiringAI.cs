using UnityEngine;
using System.Collections;

public class PlayerFiringAI : MonoBehaviour
{
	#region Public Properties
		public Transform Weapon1;
		public Transform Weapon2; //2 & 3 for other ships?
		public Transform Weapon3;
	#endregion

	#region Private Properties
		private float WeaponTimeElapsed;
		private float WeaponCooldown = 1f;
	#endregion
	
		void Start ()
		{
				WeaponTimeElapsed = 0;
		}

		void Update ()
		{
				Fire ();
		}
		void Fire ()
		{
				WeaponTimeElapsed -= Time.deltaTime;
				if (Input.GetKey (KeyCode.Space))
				if (WeaponTimeElapsed < 0) {
						WeaponTimeElapsed = WeaponCooldown;
						Instantiate (Weapon1, this.transform.position, this.transform.rotation);
						//Instantiate (Weapon2, this.transform.position + new Vector3 (this.transform.position.x + .05f, 0, 0), this.transform.rotation);
						//Instantiate (Weapon3, this.transform.position - new Vector3 (this.transform.position.x + .05f, 0, 0), this.transform.rotation);
				}
		
		
		
		
		}

}
