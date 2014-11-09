using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Container : MonoBehaviour
{

		public bool containsMineral;

		// Use this for initializationF
		void Start ()
		{
				int random = Random.Range (0, 3);
				containsMineral = random == 0 ? true : false;	
		}

}
