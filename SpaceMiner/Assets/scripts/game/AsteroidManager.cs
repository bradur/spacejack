using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour
{

		Object asteroidTemplate;
		GameObject tempAsteroid;

		void Start ()
		{
				asteroidTemplate = Resources.Load ("asteroidpref");				
				GenerateAsteroid ();

		}

		void Update ()
		{
	
		}

		public void GenerateAsteroid ()
		{
				tempAsteroid = (GameObject)Instantiate (asteroidTemplate);
				tempAsteroid.transform.position = new Vector2 (2, 1);
		}
}
