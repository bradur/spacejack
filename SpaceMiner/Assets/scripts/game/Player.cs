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
		bool isMining;

		void Start ()
		{
				prog = progressBar.GetComponent<Progress> ();
				onJourney = false;
				isMining = false;
		}

		void Update ()
		{
				if (onJourney) {
						transform.position = Vector2.MoveTowards (transform.position, travelingPoint, speed * Time.deltaTime);
						if (transform.position.x == this.travelingPoint.x && transform.position.y == this.travelingPoint.y) {
								onJourney = false;
						}
				}
				if (isMining) {
						prog.ProgressOneStep ();
				}

				
		}

		public void MoveTo (Vector3 v)
		{
				if (!onJourney) {
						this.onJourney = true;
						this.travelingPoint = v;
				}
				
		}

		void OnTriggerEnter2D (Collider2D c)
		{
				
				if (c.gameObject.tag == "home") {
						
				}
				if (c.gameObject.tag == "asteroid") {
						prog.Show ();
						isMining = true;
				}
		
		}

		void OnTriggerExit2D (Collider2D collider)
		{
				if (collider.gameObject.tag == "asteroid") {
						prog.Hide ();
						prog.SetScaleToDefault ();
						isMining = false;
				}
		}
}
