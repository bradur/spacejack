using UnityEngine;
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

		//dayTime is 120 seconds
		float dayTime = 120;
		public float ticks;

		void Start ()
		{
				//targetScale = 0;  // target scale (max) is set in scene
				//progressSprite.localScale = new Vector3 (resources.fuelAmount / 1000, progressSprite.localScale.y, progressSprite.localScale.z);
				gameObject.SetActive (true);             
				scaleY = fuelSprite.localScale.y;
				scaleZ = fuelSprite.localScale.y;
		
				maxScaleX = fuelSprite.localScale.x;

				ticks = 0;
		
		}
	
		void Update ()
		{					
				if (timer < lastTickTime + 1) {
						timer += Time.deltaTime;
				} else {
						Tick ();
				}
		
				//fuelSprite.localScale = new Vector3 (maxScaleX * ((float)resources.fuelAmount / (float)resources.maxFuelAmount), scaleY, scaleZ);
		
		}

		void Tick ()
		{
				float newScaleX = maxScaleX - maxScaleX * (ticks / dayTime);
				fuelSprite.localScale = new Vector3 (newScaleX, scaleY, scaleZ);		

				timer = Time.unscaledTime;
				lastTickTime = Time.unscaledTime;
				ticks++;
		}
}
