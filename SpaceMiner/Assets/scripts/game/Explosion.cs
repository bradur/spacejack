﻿using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{		
		public float timer;
		public float animationSpeed;
		Animator animator;

		void Start ()
		{
				animator = this.GetComponent<Animator> ();
				animator.speed = animationSpeed;
//				this.GetComponent<Animator> ().speed = animationSpeed;
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
				this.GetComponent<Animator> ().enabled = true;
		}

		public void Hide ()
		{
				this.GetComponent<Animator> ().enabled = false;
		}

		public void Show ()
		{
				transform.parent = null;
				this.GetComponent<Animator> ().enabled = true;
		}
}
