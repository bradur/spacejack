using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour
{		
		public int dmitryivanoviteAmount;
		public int sinoiteAmount;

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
				
				case Mineral.Sinoite:
						sinoiteAmount += amount;
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

public enum Tool
{
		BronzePickaxe,
		DiamondPickaxe,
		Drill,
		Laser}
;
