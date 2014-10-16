using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour
{		
		public int dmitryivanoviteAmount;

		void Start ()
		{
				dmitryivanoviteAmount = 0;
		}

		void Update ()
		{
				
		}

		public void GiveMinerals (Mineral mineralType, int amount)
		{
				if (mineralType == Mineral.Dmitryivanovite) {
						dmitryivanoviteAmount += 1;
				}
				//Debug.Log (dmitryivanoviteAmount);
		}
}

public enum Mineral
{
		Sinoite,
		Dmitryivanovite,
		Alabandite}
;
