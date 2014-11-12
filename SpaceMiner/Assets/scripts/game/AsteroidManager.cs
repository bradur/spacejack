using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidManager : MonoBehaviour
{

		Object asteroidTemplate;
		GameObject tempAsteroid;
		public GameObject playerObject;
		Player player;
		List<float> scales;
		public int asteroidsInSpace;
		public float distanceBetweenAsteroids;
		public GameObject borderOb;
		BorderManager borderManager;
		public Pirate pirate;

		void Start ()
		{
				borderManager = borderOb.GetComponent<BorderManager> ();
				asteroidTemplate = Resources.Load ("asteroidpref");     
				scales = new List<float> (){0.3f, 0.5f, 0.7f};
				GenerateAsteroids (asteroidsInSpace);
				pirate.UpdateTravelingPoint ();
		}

		public void GenerateAsteroid (float x, float y)
		{
				tempAsteroid = (GameObject)Instantiate (asteroidTemplate);
				tempAsteroid.GetComponent<Asteroid> ().playerObject = playerObject;
				tempAsteroid.transform.parent = transform;
				int scaleIndex = Random.Range (0, scales.Count);
				float scaling = scales [scaleIndex];
				tempAsteroid.transform.localScale = new Vector2 (scaling, scaling);
				tempAsteroid.transform.localPosition = new Vector2 (x, y);

				
				//Set the type of the asteroid
				// 1 - 2 = Sinoite
				// 3 - 10 = Dmitryivanovite
				int mineralType = (int)Random.Range (1, 10);
				if (mineralType < 3) {
						tempAsteroid.GetComponent<Asteroid> ().MineralType = Resource.Sinoite;
				} else if (mineralType >= 3 && mineralType <= 10) {
						tempAsteroid.GetComponent<Asteroid> ().MineralType = Resource.Dmitryivanovite;
				}

				//Set amount of minerals in asteroid
				tempAsteroid.GetComponent<Asteroid> ().MineralAmount = (int)(scaling * 1000);
		}

		public void GenerateAsteroids (int amount)
		{
				float randomX = Random.Range (borderManager.leftBorder, borderManager.rightBorder);
				float randomY = Random.Range (borderManager.downBorder, borderManager.upBorder);
				GenerateAsteroid (randomX, randomY);		
				for (int i = 0; i < amount; i++) {
						bool generate = true;
						randomX = Random.Range (borderManager.leftBorder, borderManager.rightBorder);
						randomY = Random.Range (borderManager.downBorder, borderManager.upBorder);
						Vector3 newPosition = new Vector3 (randomX, randomY, 0f);
						foreach (Transform child in transform) {
								if (Vector3.Distance (child.localPosition, newPosition) < distanceBetweenAsteroids) {
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

		public void DestroyAsteroidsInSpace ()
		{
				foreach (Transform child in transform) {
						if (child.gameObject.tag != "home") {
								Destroy (child.gameObject);
						}
				}
		}

}
