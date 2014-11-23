using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{		
		void Start ()
		{
				this.GetComponent<Animator> ().speed = 1 / 12f;				
		}

		public void Explode (float x, float y)
		{
				transform.position = new Vector3 (x, y, 0);		
				this.GetComponent<Animator> ().enabled = true;
		}
}
