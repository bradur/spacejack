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

		// Use this for initialization
		void Start ()
		{	
				menuShown = false;
				travelingPoint = offScreenOb.transform.position;
		}
	
		// Update is called once per frame
		void Update ()
		{
				transform.position = Vector3.MoveTowards (transform.position, travelingPoint, movementSpeed * Time.deltaTime);
		}

		public void TravelOnScreen ()
		{
				menuShown = true;
				travelingPoint = onScreenOb.transform.position;
		}

		public void TravelOffScreen ()
		{
				travelingPoint = offScreenOb.transform.position;
		}

		void OnMouseDown ()
		{
				menuShown = false;
				travelingPoint = offScreenOb.transform.position;
				asteroidManager.DestroyAsteroidsInSpace ();
				asteroidManager.GenerateAsteroids (asteroidManager.asteroidsInSpace);
		}
}
