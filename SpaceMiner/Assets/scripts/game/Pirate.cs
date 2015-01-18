using UnityEngine;
using System.Collections;

public class Pirate : MonoBehaviour
{
		public AsteroidManager asteroidManager;
		public GameObject managerObj;
		Vector2 myPos;
		public Vector2 travelingPoint;
		public float speed;
		public bool asteroidReached;
		public float bombPlantTimer;
		float originalBombPlantTimer;
		Asteroid asteroidScript;
		bool dayTime;
		bool onJourney;

		void Start ()
		{
				onJourney = true;
				dayTime = true;
				asteroidReached = false;
				myPos = transform.position;
		}

		void Update ()
		{
				if (dayTime) {				
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
										asteroidScript.EnableExplicitContent (this);
								}
						}
				}
		}

		public void UpdateTravelingPoint ()
		{
				float xDistance, yDistance, distanceToCurrent;		
				float nearestDistance = 1000;
				GameObject nearestAsteroid = null;
				onJourney = true;
				asteroidReached = false;
				bombPlantTimer = originalBombPlantTimer;
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
		}

		void OnTriggerEnter2D (Collider2D collider)
		{
				if (collider.gameObject.tag == "asteroid") {
						asteroidScript = collider.gameObject.GetComponent<Asteroid> ();
				}
		}

		//Stops rendering and logic
		public void StopVandalizing ()
		{
				travelingPoint = Vector3.zero;
				rigidbody2D.velocity = Vector2.zero;
				dayTime = false;
				asteroidReached = false;
				onJourney = false;
				renderer.enabled = false;
		}

		//Starts rendering and logic
		public void StartVandalizing ()
		{
				UpdateTravelingPoint ();
				renderer.enabled = true;
				dayTime = true;				
				onJourney = true;
		}
}
