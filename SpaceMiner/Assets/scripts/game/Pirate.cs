using UnityEngine;
using System.Collections;

public class Pirate : MonoBehaviour
{

		public AsteroidManager asteroidManager;
		public GameObject asteroidObj;
		Vector2 myPos;
		bool onJourney;
		public Vector2 travelingPoint;
		public float speed;

		void Start ()
		{
				myPos = transform.position;
		}

		void Update ()
		{
				if (onJourney) {
						Vector2 dir = (travelingPoint - (Vector2)transform.position).normalized;
						rigidbody2D.velocity = dir * speed * Time.deltaTime;

						if (Mathf.Abs (transform.position.x - travelingPoint.x) < 0.1 && Mathf.Abs (transform.position.y - travelingPoint.y) < 0.1) {
								rigidbody2D.velocity = Vector2.zero;
								onJourney = false;
						}
				} else {
						UpdateTravelingPoint ();
						onJourney = true;
				}	
		}

		void UpdateTravelingPoint ()
		{	
				float xDistance, yDistance, distanceToCurrent;		
				float nearestDistance = 1000;

				foreach (Transform child in asteroidObj.GetComponentsInChildren<Transform>()) {
						if (child.gameObject.tag == "asteroid") {
								xDistance = myPos.x - child.transform.position.x;
								yDistance = myPos.y - child.transform.position.y;
								distanceToCurrent = Mathf.Sqrt (Mathf.Pow (xDistance, 2) + Mathf.Pow (yDistance, 2));
								if (distanceToCurrent < nearestDistance) {
										nearestDistance = distanceToCurrent;
										travelingPoint = child.transform.position;
								}
						}
				}

		}

}
