using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
		public float speed;
		// Use this for initialization
		bool onJourney;
		Vector2 travelingPoint;

		void Start ()
		{
				onJourney = false;
		}

		void Update ()
		{
				if (onJourney) {
						transform.position = Vector2.MoveTowards (transform.position, travelingPoint, speed * Time.deltaTime);
						if (transform.position.x == this.travelingPoint.x && transform.position.y == this.travelingPoint.y) {
								onJourney = false;
						}
				}
		}

		public void MoveTo (Vector3 v)
		{
				if (!onJourney) {
						this.onJourney = true;
						this.travelingPoint = v;
				}
				
		}
}
