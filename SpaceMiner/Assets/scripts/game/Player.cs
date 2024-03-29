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
		public HudManager hudManager;
		GameObject lastCollider = null;
		float fuelUsageTimer;
		public GameObject home;
		public GridManager miniGame;
		public Pirate pirateShip;
		public AudioSource fuelLow;
		public float fuelLowSoundTickRate;
		float fuelLowSoundTimer;

		void Start ()
		{
				progressbar = progressBar.GetComponent<Progress> ();
				onJourney = false;
				asteroidReached = false;
				farmingTool = Tool.DiamondPickaxe;
				resources = resourceManager.GetComponent<ResourceManager> ();

				fuelUsageTimer = Time.deltaTime;
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
										if (lastCollider != null) {
												/*progressbar.SetTarget (lastCollider);
												progressbar.StartProcess (farmingSpeed);*/
												pirateShip.StopMoving ();
												miniGame.InitializeGame (lastCollider.GetComponent<Asteroid> ());
										}
										
								}
						}
				} else if (!onJourney) {
						fuelUsageTimer = Time.unscaledTime;
				}

				if (hudManager.resourceManager.fuelAmount < hudManager.resourceManager.maxFuelAmount / 3 && !fuelLow.isPlaying) {
						fuelLowSoundTimer += Time.deltaTime;
						if (hudManager.resourceManager.fuelAmount > hudManager.resourceManager.maxFuelAmount / 6 && fuelLowSoundTimer > fuelLowSoundTickRate) {
								fuelLowSoundTimer = 0;
								fuelLow.Play ();
						}
						else if (hudManager.resourceManager.fuelAmount < hudManager.resourceManager.maxFuelAmount / 6) {
								fuelLow.Play ();
						}
				}

		}
		//uses fuelConsumption amount of fuel per second
		void UseFuel ()
		{
				if (fuelUsageTimer + 1 < Time.unscaledTime) {
						fuelUsageTimer = Time.unscaledTime;
						hudManager.UseFuel (fuelConsumption);
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

		public void TravelHome ()
		{
				travelingPoint = home.transform.position;
				transform.position = home.transform.position;
				onJourney = false;
				rigidbody2D.velocity = Vector3.zero;
				progressbar.EndProcess ();
		}
}



