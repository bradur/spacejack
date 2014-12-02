using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{		
		public float timer;
		public float animationSpeed;
		Animator animator;

		//Countdown number and explosion animation uses this class. They have different timers for their animations. 
		//Methods are called from Asteroid and ExplosionNumber.
		void Start ()
		{
				animator = this.GetComponent<Animator> ();
				animator.speed = animationSpeed;
		}

		void Update ()
		{
				timer -= Time.deltaTime;
				if (timer < 0) {
						Destroy (this.gameObject);
				}
		}

		public void Explode (float x, float y)
		{
				transform.position = new Vector3 (x, y, 0);		
				Show ();
		}

		public void Hide ()
		{
				this.GetComponent<Renderer> ().enabled = false;
				this.GetComponent<Animator> ().enabled = false;
		}

		public void Show ()
		{
				transform.parent = null;
				this.GetComponent<Renderer> ().enabled = true;
				this.GetComponent<Animator> ().enabled = true;
		}
}
