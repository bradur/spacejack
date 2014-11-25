using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{		
		public float timer;

		void Start ()
		{
				this.GetComponent<Animator> ().speed = 1 / 12f;	
				timer = 3;
		}

		void Update ()
		{
				timer -= Time.deltaTime;
				if (timer < 0) {
					Destroy(this.gameObject);
				}
		}

		public void Explode (float x, float y)
		{
				transform.position = new Vector3 (x, y, 0);		
				this.GetComponent<Animator> ().enabled = true;
		}
}
