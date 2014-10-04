using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
		public float speed;
		// Use this for initialization
		bool onJourney;
		Vector2 travelingPoint;
		Progress prog;
		public GameObject progressBar;

		void Start ()
		{
				prog = progressBar.GetComponent<Progress> ();
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
				if (!onJourney) {
						//prog.ProgressOneStep ();
				}

				
		}

		public void MoveTo (Vector3 v)
		{
				if (!onJourney) {
						this.onJourney = true;
						this.travelingPoint = v;
				}
				
		}

		void OnCollisionEnter2D (Collision2D c)
		{
				Debug.Log ("huhuu");
				if (c.gameObject.tag == "home") {
						Debug.Log ("jee");
				}
		}
}
