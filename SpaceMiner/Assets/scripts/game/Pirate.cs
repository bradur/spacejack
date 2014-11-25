﻿using UnityEngine;
using System.Collections;

public class Pirate : MonoBehaviour
{
		public ExplosionNumber expNumber;
		public AsteroidManager asteroidManager;
		public GameObject managerObj;
		Vector2 myPos;
		public Vector2 travelingPoint;
		public float speed;
		public bool asteroidReached;
		public bool onJourney;
		public float bombPlantTimer;
		public float bombExplosionTimer;
		float originalBombPlantTimer;
		float originalBombExplosionTimer;
		GameObject asteroid;

		void Start ()
		{
				onJourney = true;
				asteroidReached = false;
				myPos = transform.position;
				originalBombPlantTimer = bombPlantTimer;
				originalBombExplosionTimer = bombExplosionTimer;
		}

		void Update ()
		{
				if (onJourney) {
						Vector2 dir = (travelingPoint - (Vector2)transform.position).normalized;
						rigidbody2D.velocity = dir * speed * Time.deltaTime;

						if (Mathf.Abs (transform.position.x - travelingPoint.x) < 0.1 && Mathf.Abs (transform.position.y - travelingPoint.y) < 0.1) {
								rigidbody2D.velocity = Vector2.zero;
								onJourney = false;
								asteroidReached = true;
								
						}
				} 
				if (asteroidReached) {
						//When asteroid reached, plant the bomb.
						bombPlantTimer -= Time.deltaTime;
						if (bombPlantTimer < 0) {
								onJourney = true;
								asteroidReached = false;
								if (asteroid != null) {
										//Call asteroids explode method to destroy it
										expNumber.StartCounting ();
										//makes explosion animation and links it to current asteroid
										expNumber.SetupExplosionForAsteroid (asteroid);
										asteroid.GetComponent<Asteroid> ().ExplodeInSeconds (bombExplosionTimer);
								}
								UpdateTravelingPoint ();
								bombPlantTimer = originalBombPlantTimer;
						}						
				}
		}

		public void UpdateTravelingPoint ()
		{	
				float xDistance, yDistance, distanceToCurrent;		
				float nearestDistance = 1000;
				GameObject nearestAsteroid = null;
				foreach (Transform child in managerObj.GetComponentsInChildren<Transform>()) {
						if (child.gameObject.tag == "asteroid") {
								xDistance = myPos.x - child.transform.position.x;
								yDistance = myPos.y - child.transform.position.y;
								distanceToCurrent = Mathf.Sqrt (Mathf.Pow (xDistance, 2) + Mathf.Pow (yDistance, 2));
								if (distanceToCurrent < nearestDistance) {
										nearestDistance = distanceToCurrent;
										travelingPoint = child.transform.position;
										nearestAsteroid = child.gameObject;
								}
						}
				}
				if (nearestAsteroid != null) {
						nearestAsteroid.transform.parent = null;
				}

		}

		void OnTriggerEnter2D (Collider2D collider)
		{
				asteroid = collider.gameObject;
		}


}
