using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{		
//		public float timer;

		void Start ()
		{
				this.GetComponent<Animator> ().speed = 1 / 12f;	
				Explode (transform.position.x, transform.position.y);
		}

//		void Update ()
//		{
//				timer -= Time.deltaTime;
//		}

		public void Explode (float x, float y)
		{
				transform.position = new Vector3 (x, y, 0);		
				this.GetComponent<Animator> ().enabled = true;
		}
}
