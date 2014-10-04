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
						Vector2 dir = (travelingPoint - (Vector2)transform.position).normalized;
						rigidbody2D.velocity = dir * speed;
						if (Mathf.Abs (transform.position.x - travelingPoint.x) < 0.01 && Mathf.Abs (transform.position.y - travelingPoint.y) < 0.01) {
								rigidbody2D.velocity = Vector2.zero;
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
				Debug.Log ("hv");
				if (collider.gameObject.tag == "asteroid") {
						prog.Hide ();
						prog.SetScaleToDefault ();
						isMining = false;
				}
		}
}
