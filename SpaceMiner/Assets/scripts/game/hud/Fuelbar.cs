using UnityEngine;
using System.Collections;

public class Fuelbar : MonoBehaviour
{

		public Transform fuelSprite;
		public float scaleSpeed = 1f;
		Vector3 targetScale;
		public GameObject resourceManager;
		ResourceManager resources;
		bool isActive = false;
		float scaleY;
		float scaleZ;
		float maxScaleX;

		void Start ()
		{
				//targetScale = 0;  // target scale (max) is set in scene
				//progressSprite.localScale = new Vector3 (resources.fuelAmount / 1000, progressSprite.localScale.y, progressSprite.localScale.z);
				gameObject.SetActive (true);             // disable
		
				resources = resourceManager.GetComponent<ResourceManager> ();
				scaleY = fuelSprite.localScale.y;
				scaleZ = fuelSprite.localScale.y;
				
				maxScaleX = fuelSprite.localScale.x;
				
		}
	
		void Update ()
		{					
				
				fuelSprite.localScale = new Vector3 (maxScaleX * ((float)resources.fuelAmount / (float)resources.maxFuelAmount), scaleY, scaleZ);
                                            
		}
}
