using UnityEngine;
using System.Collections;

public class ExplosionNumber : MonoBehaviour
{

		Object explosionTimerTemplate;
		GameObject explosionTimer;
		Object asteroidExplosionTemplate;
		GameObject asteroidExplosion;
		

		// Use this for initialization
		void Start ()
		{
				explosionTimerTemplate = Resources.Load ("explosionNumbers");
				asteroidExplosionTemplate = Resources.Load ("asteroidExplosion");
		}

		public void StartCounting ()
		{
				explosionTimer = (GameObject)Instantiate (explosionTimerTemplate);
				explosionTimer.GetComponent<Explosion> ().Explode (transform.position.x, transform.position.y);			
		}

		public void SetupExplosionForAsteroid (GameObject asteroid)
		{
				if (asteroid == null) {
						return;
				}
				asteroidExplosion = (GameObject)Instantiate (asteroidExplosionTemplate);
				asteroid.GetComponent<Asteroid> ().SetAsteroidExplosion (asteroidExplosion);
				asteroidExplosion.GetComponent<Explosion> ().Hide ();
		}
}
