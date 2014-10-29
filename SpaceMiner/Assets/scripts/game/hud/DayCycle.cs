﻿using UnityEngine;
using System.Collections;

public class DayCycle : MonoBehaviour
{

		public Transform fuelSprite;
		public float scaleSpeed = 1f;
		Vector3 targetScale;
		bool isActive = false;
		float scaleY;
		float scaleZ;
		float maxScaleX;
		float timer;
		float lastTickTime;
		public GameObject playerOb;
		Player playerScript;
		public GameObject dayPassedObject;
		DayPassedMenu dayPassedScript;
		public AsteroidManager asteroidManager;

		//dayTime is 120 seconds
		public float dayTime;
		float ticks;

		void Start ()
		{
				//targetScale = 0;  // target scale (max) is set in scene
				//progressSprite.localScale = new Vector3 (resources.fuelAmount / 1000, progressSprite.localScale.y, progressSprite.localScale.z);
				gameObject.SetActive (true);             
				scaleY = fuelSprite.localScale.y;
				scaleZ = fuelSprite.localScale.y;
		
				maxScaleX = fuelSprite.localScale.x;

				ticks = 0;
				playerScript = playerOb.GetComponent<Player> ();
				dayPassedScript = dayPassedObject.GetComponent<DayPassedMenu> ();
		}
	
		void Update ()
		{					
				if (timer < lastTickTime + 1 && !dayPassedScript.menuShown) {
						timer += Time.deltaTime;
				} else if (!dayPassedScript.menuShown && timer >= lastTickTime + 1) {
						Tick ();
				}		
		}

		void Tick ()
		{
				float newScaleX = maxScaleX - maxScaleX * (ticks / dayTime);
				fuelSprite.localScale = new Vector3 (newScaleX, scaleY, scaleZ);		

				timer = Time.unscaledTime;
				lastTickTime = Time.unscaledTime;
				ticks++;
				if (ticks > dayTime) {
						playerScript.TravelHome ();
						dayPassedScript.TravelOnScreen ();
						ticks = 0;
						fuelSprite.localScale = new Vector3 (maxScaleX, scaleY, scaleZ);
						asteroidManager.DestroyAsteroidsInSpace ();
						asteroidManager.GenerateAsteroids (asteroidManager.asteroidsInSpace);
				}
		}
}
