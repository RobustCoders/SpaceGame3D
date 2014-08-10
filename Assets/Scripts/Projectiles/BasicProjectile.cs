using UnityEngine;
using System.Collections;

public class BasicProjectile : MonoBehaviour
{

	
	#region Public Properties
		public Transform Pointer;
	#endregion
	
	#region Private Properties
		private float baseSpeed;
		private float TimeToDie;
		private float ElapsedTime;
		private float burnOutDistance;
	#endregion
	
		void Start ()
		{
				baseSpeed = 40f;
				ElapsedTime = 0;
				TimeToDie = 10f;
				burnOutDistance = 0f;
		}
	
		void Update ()
		{
				this.transform.position = Vector3.MoveTowards (this.transform.position, Pointer.transform.position, baseSpeed * Time.deltaTime);
				ElapsedTime += Time.deltaTime;
				if (ElapsedTime > TimeToDie)
						StartCoroutine (_Die ());
				
		}
	
		void OnTriggerEnter (Collider other)
		{
				if (other.gameObject.GetComponent <PlayerMovementAI> () == null)
						StartCoroutine (_Die ());
		
		
		
		}
	
		IEnumerator _Die ()
		{
				yield return new WaitForSeconds (.05f);
				Destroy (this.gameObject);
		
		
		}
}
