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
				switch (mineralType) {
				case Mineral.Dmitryivanovite:
						dmitryivanoviteAmount += amount;
						break;
				}
		}
}

public enum Mineral
{
		Sinoite,
		Dmitryivanovite,
		Alabandite}
;
