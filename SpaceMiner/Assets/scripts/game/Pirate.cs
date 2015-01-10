using UnityEngine;
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
		public float bombPlantTimer;
		public float bombExplosionTimer;
		float originalBombPlantTimer;
		float originalBombExplosionTimer;
		GameObject asteroid;
		bool dayTime;
		bool onJourney;

		void Start ()
		{
				onJourney = true;
				dayTime = true;
				asteroidReached = false;
				myPos = transform.position;
				originalBombPlantTimer = bombPlantTimer;
				originalBombExplosionTimer = bombExplosionTimer;
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
										onJourney = true;
										asteroidReached = false;
										bombPlantTimer = originalBombPlantTimer;
										if (asteroid != null) {
												//Instantiate countdown numbers
												expNumber.StartCounting ();
												//Asteroid will destroy at the same time as countdown goes to zero
												asteroid.GetComponent<Asteroid> ().ExplodeInSeconds (bombExplosionTimer);
												//makes explosion for asteroid animation and links it to current asteroid
												expNumber.SetupExplosionForAsteroid (asteroid);
										} else {
												//Todo: destroy asteroids explosion animation/countdown when day ends.
												Debug.Log ("horo");
												expNumber.DestroyExplosionAnimations ();
										
										}
								}
								UpdateTravelingPoint ();
						}
				}
		}

		public void UpdateTravelingPoint ()
		{	
				float xDistance, yDistance, distanceToCurrent;		
				float nearestDistance = 1000;
				GameObject nearestAsteroid = null;
				//When new day comes, this does not work, it checks from old children list? :o
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
//				if (nearestAsteroid != null) {
//						nearestAsteroid.transform.parent = null;
//				}
//				Debug.Log ("Traveling towards x: " + nearestAsteroid.transform.localPosition.x + " y: " + nearestAsteroid.transform.localPosition.y);


		}

		void OnTriggerEnter2D (Collider2D collider)
		{
				asteroid = collider.gameObject;
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
