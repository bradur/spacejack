using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
		public GameObject progressBar;
		public float speed;
		public int fuelConsumption;
		bool onJourney;
		bool asteroidReached;
		Vector2 travelingPoint;
		Progress progressbar;
		int farmingSpeed;
		Tool farmingTool;
		public GameObject resourceManager;
		ResourceManager resources;
		GameObject lastCollider = null;
		float fuelTimer;

		void Start ()
		{
				progressbar = progressBar.GetComponent<Progress> ();
				onJourney = false;
				asteroidReached = false;
				farmingTool = Tool.DiamondPickaxe;
				resources = resourceManager.GetComponent<ResourceManager> ();

				fuelTimer = Time.deltaTime;
		}

		void Update ()
		{
				if (onJourney && resources.fuelAmount > 0) {
						Vector2 dir = (travelingPoint - (Vector2)transform.position).normalized;
						rigidbody2D.velocity = dir * speed * Time.deltaTime;

						
						UseFuel ();
						
						if (Mathf.Abs (transform.position.x - travelingPoint.x) < 0.1 && Mathf.Abs (transform.position.y - travelingPoint.y) < 0.1) {
								rigidbody2D.velocity = Vector2.zero;
								onJourney = false;
								// show progress bar only after player has stopped on the asteroid, not immediately when colliding
								if (asteroidReached) {
										switch (farmingTool) {
										case Tool.BronzePickaxe:
												farmingSpeed = 1;
												break;
										case Tool.DiamondPickaxe:
												farmingSpeed = 2;
												break;
										default:
												farmingSpeed = 0;
												break;
										}
										if(lastCollider != null){
											progressbar.SetTarget(lastCollider);
											progressbar.StartProcess(farmingSpeed);
										}
										
								}
						}
				} else if (!onJourney) {
						fuelTimer = Time.unscaledTime;
				}

		}
	//uses fuelConsumption amount of fuel per second
		void UseFuel ()
		{
				if (fuelTimer + 1 < Time.unscaledTime) {
						resources.fuelAmount -= fuelConsumption;
						fuelTimer = Time.unscaledTime;
				}
		}

		public void MoveTo (Vector3 targetPosition)
		{
				// hide progress bar when player starts to move
				if (asteroidReached) {
						progressbar.EndProcess ();
				}
				if (!onJourney) {
						onJourney = true;
						travelingPoint = targetPosition;
				}
				asteroidReached = false;
		}

		void OnTriggerEnter2D (Collider2D collider)
		{
        
				if (collider.gameObject.tag == "home") {
					lastCollider = null;
				}
				if (collider.gameObject.tag == "asteroid") {
					asteroidReached = true;
					lastCollider = collider.gameObject;
				}
    
		}

		public Tool FarmintTool {
				get {
						return this.farmingTool;
				}

				set {
						this.farmingTool = value;
				}
		}

}



