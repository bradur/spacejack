using UnityEngine;
using System.Collections;

public class DayPassedMenu : MonoBehaviour
{
		public GameObject offScreenOb;
		public GameObject onScreenOb;
		public float movementSpeed;
		Vector3 travelingPoint;
		public bool menuShown;
		public AsteroidManager asteroidManager;
		public Pirate pirate;

		void Start ()
		{	
				menuShown = false;
				travelingPoint = offScreenOb.transform.position;
		}

		void Update ()
		{
				transform.position = Vector3.MoveTowards (transform.position, travelingPoint, movementSpeed * Time.deltaTime);
		}

		public void TravelOnScreen ()
		{		
				//*******Add some vandalizing condition here (or in pirate)*********
				pirate.StopVandalizing ();
				menuShown = true;
				travelingPoint = onScreenOb.transform.position;
		}

		public void TravelOffScreen ()
		{				
				pirate.StartVandalizing ();
				travelingPoint = offScreenOb.transform.position;
		}

		void OnMouseDown ()
		{
				menuShown = false;
				asteroidManager.DestroyAsteroidsInSpace ();
				asteroidManager.GenerateAsteroids (asteroidManager.asteroidsInSpace);
				TravelOffScreen ();
		}
}
