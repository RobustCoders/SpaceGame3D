using UnityEngine;
using System.Collections;

public class TrackingProjectile : MonoBehaviour
{

	#region Public Properties
		public Transform Target;
		public Component Marker;
	#endregion

	#region Private Properties
		private float baseSpeed;
	#endregion

		void Start ()
		{
				baseSpeed = 50f;
				//if (gameObject.GetComponent<Marker> ())
				//		Target = gameObject.GetComponent<Marker> ();
		}

		void Update ()
		{
				this.transform.position = Vector3.MoveTowards (this.transform.position, Target.transform.position, baseSpeed * Time.deltaTime);
		                                              
		}

		void OnTriggerEnter (Collider other)
		{
				StartCoroutine (_Die ());



		}

		IEnumerator _Die ()
		{
				yield return new WaitForSeconds (.2f);
				Destroy (this.gameObject);


		}
}
