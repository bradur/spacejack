using UnityEngine;
using System.Collections;

public class HudManager : MonoBehaviour
{

		public ResourceManager resourceManager;
		TextMesh[] text = new TextMesh[System.Enum.GetNames (typeof(Resource)).Length];
		public GameObject[] indicatorList = new GameObject[System.Enum.GetNames (typeof(Resource)).Length];
		// Use this for initialization
		void Start ()
		{	
				UpdateHud ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void UpdateResources (Resource resource, int amount)
		{
				resourceManager.UpdateResourceCount (resource, amount);
				UpdateHud ();
		}

		public void UseFuel (int amount)
		{
				resourceManager.fuelAmount -= amount;				
		}
		
		void UpdateHud ()
		{
				for (int i = 0; i < text.Length - 1; i++) {
						Resource indicatorsResource = indicatorList [i].GetComponent<Indicator> ().resource;
						if (indicatorsResource == Resource.Fuel) {
						} else {
								indicatorList [i].GetComponent<TextMesh> ().text = "" + resourceManager.GetResourceCount (indicatorsResource);
						}			
				}
		}
}
