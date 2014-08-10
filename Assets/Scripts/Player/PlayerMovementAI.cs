using UnityEngine;
using System.Collections;

public class PlayerMovementAI : MonoBehaviour
{
	#region Public Properties
		public Transform Pointer;
		public Transform ThreePCamera;

	#endregion 

	#region Private Properties
		private float turnSpeed = 20;
		private float baseSpeed = 2f;
		private float movementSpeed;
		private float speedMultiplier;
		
		private bool subWarpOn;
		private float subWarpMultiplier;
		private float subWarpMax = 25f;

		private bool warpOn;
		private float warpMultiplier;
		private float warpMax = 500f;
	
	#endregion

		void Start ()
		{
				movementSpeed = baseSpeed;
				speedMultiplier = 0;
				
				subWarpOn = false;
				subWarpMultiplier = 1;
				
				warpOn = false;
				warpMultiplier = 1f;
				
		}

		void Update ()
		{
				Move ();
				AdjustThrust ();
				Yaw ();
				Pitch ();
				Roll ();
		}

		void Move ()
		{

				
				if (subWarpOn) {
						if (subWarpMultiplier < subWarpMax) {
								subWarpMultiplier += .2f;
						}
				} else {
						if (subWarpMultiplier > 1f) {
								subWarpMultiplier -= .2f;
						}
				}

				if (warpOn) {
						if (warpMultiplier < warpMax) {
								warpMultiplier += 3.334f;
						}
						if (ThreePCamera.camera.fieldOfView < 129 && speedMultiplier > 0) {
								ThreePCamera.camera.fieldOfView++;
						}
			
				} else {
						if (warpMultiplier > 1f) {
								warpMultiplier -= 3.334f;
						}
						if (ThreePCamera.camera.fieldOfView > 61) {
								ThreePCamera.camera.fieldOfView--;
						}
				}

				//float Yrotation = this.transform.rotation.eulerAngles.y;
				movementSpeed = baseSpeed * Time.deltaTime * speedMultiplier;

				if (warpOn) {
						this.transform.position = Vector3.MoveTowards (this.transform.position, Pointer.transform.position, movementSpeed * warpMultiplier);
				} else {
						this.transform.position = Vector3.MoveTowards (this.transform.position, Pointer.transform.position, movementSpeed * subWarpMultiplier);
				}
				
		}

		void AdjustThrust ()
		{
				if (!warpOn) {
						if (Input.GetKeyDown (KeyCode.RightBracket)) {
								if (speedMultiplier < 1) 
										speedMultiplier += .25f;
						} else if (Input.GetKeyDown (KeyCode.LeftBracket)) {
								if (speedMultiplier > -0.25) 
										speedMultiplier -= .25f;
						}

						if (Input.GetKeyDown (KeyCode.Return)) {
								if (subWarpOn)
										subWarpOn = false;
								else 
										subWarpOn = true;
						}
				}

				//Toggles warp
				if (Input.GetKeyDown (KeyCode.Tab)) {
						if (warpOn) {
								warpOn = false;
								Debug.Log ("Dropping out of warp");
								speedMultiplier = .25f;
						} else
								StartCoroutine (_EngageWarp ());
						
				}


		}

		void Yaw ()
		{
				if (Input.GetKey (KeyCode.A)) {
						this.transform.Rotate (0, turnSpeed * Time.deltaTime * -1, 0);
						this.transform.Rotate (0, 0, turnSpeed * Time.deltaTime * .2f);
				} else if (Input.GetKey (KeyCode.D)) {
						this.transform.Rotate (0, turnSpeed * Time.deltaTime, 0);
						this.transform.Rotate (0, 0, turnSpeed * Time.deltaTime * -1 * .2f);
				}
		}

		void Pitch ()
		{
				if (Input.GetKey (KeyCode.W)) {
						this.transform.Rotate (turnSpeed * Time.deltaTime, 0, 0);
				} else if (Input.GetKey (KeyCode.S)) {
						this.transform.Rotate (turnSpeed * Time.deltaTime * -1, 0, 0);
				}
		}

		void Roll ()
		{
				if (Input.GetKey (KeyCode.Q)) {
						this.transform.Rotate (0, 0, turnSpeed * Time.deltaTime);
				} else if (Input.GetKey (KeyCode.E)) {
						this.transform.Rotate (0, 0, turnSpeed * Time.deltaTime * -1);
				}
		}

		IEnumerator _EngageWarp ()
		{
				Debug.Log ("Engaging warp drive");
				Debug.Log ("Diverting main power to warp field");
				yield return new WaitForSeconds (3f);
				Debug.Log ("Diverting power from impulse engines");
				speedMultiplier = 0;
				yield return new WaitForSeconds (2f);
				if (subWarpOn) {
						subWarpOn = false;
						Debug.Log ("Diverting power from subwarp multiplexer engines");
				}
				Debug.Log ("Warp drive is online");
				speedMultiplier = 1;

				warpOn = true;
		}

		
		

}

/* Useless Code


				//z is 2D y axis for mathematical purposes
				float xBearing = Mathf.Atan (Yrotation * Mathf.Deg2Rad) * Mathf.Rad2Deg;
				float zBearing = Mathf.Atan (Yrotation * Mathf.Deg2Rad) * Mathf.Rad2Deg;		
				
				float xa = baseSpeed * Time.deltaTime * speedMultiplier * xBearing;
				float za = baseSpeed * Time.deltaTime * speedMultiplier * 1;

				

				Debug.Log ("Current X movement: " + xa);
				Debug.Log ("Current Y rotation: " + Yrotation);
				Debug.Log ("Current Z movement: " + za);

				this.transform.position += new Vector3 (baseSpeed * Time.deltaTime * speedMultiplier * 1,
		                                        		baseSpeed * Time.deltaTime * speedMultiplier * 0, 
		                                        		baseSpeed * Time.deltaTime * speedMultiplier * zBearing);  
		                                        		*/
