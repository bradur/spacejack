using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidManager : MonoBehaviour
{

		Object asteroidTemplate;
		GameObject tempAsteroid;
		public GameObject player;
		Player p;
		List<float> scales;
		int asteroidsInSpace = 5;
		public float distanceBetweenAsteroids;

		void Start ()
		{
				asteroidTemplate = Resources.Load ("asteroidpref");		
				scales = new List<float> (){0.3f, 0.6f, 0.9f};

				float randomX = Random.Range (-6, 6);
				float randomY = Random.Range (-4, 4);
				GenerateAsteroid (randomX, randomY);

				for (int i = 0; i < asteroidsInSpace; i++) {
						bool generate = true;
						randomX = Random.Range (-6, 6);
						randomY = Random.Range (-4, 4);
						foreach (Transform child in transform) {
								Debug.Log (Mathf.Abs (child.localPosition.x - tempAsteroid.transform.localPosition.x));
								if (Mathf.Abs (child.localPosition.x - randomX) < distanceBetweenAsteroids && Mathf.Abs (child.localPosition.y - tempAsteroid.transform.localPosition.y) < distanceBetweenAsteroids) {
										generate = false;
										break;
								}
						}

						if (generate) {
								GenerateAsteroid (randomX, randomY);
						} else {
								i--;
						}
				}
		}
	
		void Update ()
		{
	
		}

		public void GenerateAsteroid (float x, float y)
		{				
				tempAsteroid = (GameObject)Instantiate (asteroidTemplate);
				tempAsteroid.transform.parent = transform;
				int scaleIndex = Random.Range (0, scales.Count);
				float scaling = scales [(int)Random.Range (0, 2)];
				tempAsteroid.transform.localScale = new Vector2 (scaling, scaling);
				tempAsteroid.transform.position = new Vector2 (x, y);		


		}
}
