using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour
{		
		public int dmitryivanoviteAmount;
		public int sinoiteAmount;
		public int fuelAmount;

		void Start ()
		{

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

		public int FuelAmount {
				set{ this.fuelAmount = value;}
				get{ return this.fuelAmount;}
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

public enum JetPackUpgrade
{
		Lazy,
		TheBeast,
		Expert


}
