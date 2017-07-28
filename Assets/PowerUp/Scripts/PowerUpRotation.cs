using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpRotation : MonoBehaviour
{

	#region Settings
	public float rotationSpeed = 99.0f;
	public bool reverse = false;
	#endregion

	void Update ()
	{
		if (this.reverse) {
			if (this.name == "AltLife Turtle")
				transform.Rotate (new Vector3 (0f, 0f, 1f) * Time.deltaTime * this.rotationSpeed);
			else if (this.name == "Heater_Shield" || (this.name == "coin"))
				transform.Rotate (new Vector3 (0f, 1f, 0f) * Time.deltaTime * this.rotationSpeed);
		} else {
			if (this.name == "AltLife Turtle") 
				transform.Rotate (new Vector3 (0f, 0f, 1f) * Time.deltaTime * this.rotationSpeed);
			else if (this.name == "Heater_Shield" || (this.name == "coin"))
				transform.Rotate (new Vector3 (0f, 1f, 0f) * Time.deltaTime * this.rotationSpeed);
		}

	}

	public void SetRotationSpeed(float speed)
	{
		this.rotationSpeed = speed;
	}

	public void SetReverse(bool reverse)
	{
		this.reverse = reverse;
	}
}
