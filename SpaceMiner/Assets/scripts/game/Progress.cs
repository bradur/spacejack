using UnityEngine;
using System.Collections;

public class Progress : MonoBehaviour
{
	float scaleStep = 0.1f;
	
	void Update ()
	{
		if (Input.GetKeyUp ("left")) {
			Debug.Log ("?");

		}
	}

	public void ProgressOneStep ()
	{
		transform.localScale = new Vector3 (transform.localScale.x + scaleStep, transform.localScale.y, transform.localScale.z);
	}
}
