using UnityEngine;
using System.Collections;

public class ExplosionNumber : MonoBehaviour
{

		Object explosionTimerTemplate;
		GameObject explosionTimer;
		Object asteroidExplosionTemplate;
		GameObject asteroidExplosion;
		GameObject currentAsteroid;

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
				currentAsteroid = asteroid;
				asteroidExplosion = (GameObject)Instantiate (asteroidExplosionTemplate);
				asteroid.GetComponent<Asteroid> ().SetAsteroidExplosion (asteroidExplosion);
				asteroidExplosion.transform.position = new Vector3 (asteroid.transform.position.x, asteroid.transform.position.y, 0);
				asteroidExplosion.GetComponent<Explosion> ().Hide ();
		}

		public void DestroyExplosionAnimations ()
		{
				Destroy (currentAsteroid);
		}
}
