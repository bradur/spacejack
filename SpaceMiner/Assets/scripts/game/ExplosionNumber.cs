using UnityEngine;
using System.Collections;

public class ExplosionNumber : MonoBehaviour
{

		Object explosionTimerTemplate;
		GameObject explosionTimer;

		// Use this for initialization
		void Start ()
		{
				explosionTimerTemplate = Resources.Load ("explosionNumbers");
		}

		public void StartCounting ()
		{
				explosionTimer = (GameObject)Instantiate (explosionTimerTemplate);
				explosionTimer.GetComponent<Explosion> ().Explode (transform.position.x, transform.position.y);
		}
}
