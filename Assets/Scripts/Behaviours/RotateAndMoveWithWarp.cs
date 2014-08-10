using UnityEngine;
using System.Collections;

public class RotateAndMoveWithWarp : MonoBehaviour
{

	#region Public Properties
		public bool RandomizeSpeed = false;
		public bool RandomizeRotation = false;

		public float xSpeed;
		public float ySpeed;
		public float zSpeed;
		public float rotationSpeed;
	#endregion
	
	#region Private Properties
		private float xSpeedMinimum = 0;
		private float xSpeedMaximum = 1.5f;
		private float ySpeedMinimum = 0;
		private float ySpeedMaximum = 1.5f;
		private float zSpeedMinimum = 0;
		private float zSpeedMaximum = 1.5f;

		private float rotationSpeedMinimum = 0;
		private float rotationSpeedMaximum = 60;

		private const float xMinimum = -500;
		private const float xMaximum = 500;
		private const float yMinimum = -500;
		private const float yMaximum = 500;
		private const float zMinimum = -500;
		private const float zMaximum = 500;
	#endregion

		// Use this for initialization
		void Start ()
		{
				if (RandomizeSpeed) {
						xSpeed = Random.Range (xSpeedMinimum, xSpeedMaximum) - 1;
						ySpeed = Random.Range (ySpeedMinimum, ySpeedMaximum) - 1;
						zSpeed = Random.Range (zSpeedMinimum, zSpeedMaximum) - 1;
				}

				if (RandomizeRotation) {
						rotationSpeed = Random.Range (rotationSpeedMinimum, rotationSpeedMaximum);
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
				// Move the object
				float newX = this.transform.position.x + Time.deltaTime * xSpeed;
				float newY = this.transform.position.y + Time.deltaTime * ySpeed;
				float newZ = this.transform.position.z + Time.deltaTime * zSpeed;

				if (newX < xMinimum)
						newX = xMaximum;
				if (newX > xMaximum)
						newX = xMinimum;
				if (newY < yMinimum)
						newY = yMaximum;
				if (newY > yMaximum)
						newY = yMinimum;
				if (newZ < zMinimum)
						newZ = zMaximum;
				if (newZ > yMaximum)
						newZ = zMinimum;

				this.transform.position = new Vector3 (newX, newY, newZ);
		
				this.transform.localEulerAngles += new Vector3 (Time.deltaTime * rotationSpeed, Time.deltaTime * rotationSpeed, Time.deltaTime * rotationSpeed);
		}
}
