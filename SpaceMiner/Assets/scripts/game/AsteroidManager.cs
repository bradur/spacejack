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
								if (Mathf.Abs (child.localPosition.x - randomX) < child.transform.localScale.x * 2f && Mathf.Abs (child.localPosition.y - tempAsteroid.transform.localPosition.y) < child.transform.localScale.x * 2f) {
										generate = false;
										break;
								}
						}

						if (generate) {
								GenerateAsteroid (randomX, randomY);
						} else {
								//i--;
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
				tempAsteroid.transform.localScale = new Vector2 (1.3f, 1.3f);
				tempAsteroid.transform.position = new Vector2 (x, y);		


		}
}
