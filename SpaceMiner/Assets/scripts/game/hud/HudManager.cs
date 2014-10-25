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
				for (int i = 0; i < text.Length; i++) {
						Resource indicatorsResource = indicatorList [i].GetComponent<Indicator> ().resource;
						if (indicatorsResource == Resource.Fuel) {
								indicatorList [i].GetComponent<TextMesh> ().text = resourceManager.GetResourceCount (indicatorsResource) + "/" + resourceManager.maxFuelAmount;
						} else {
								indicatorList [i].GetComponent<TextMesh> ().text = "" + resourceManager.GetResourceCount (indicatorsResource);
						}
						

				}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void UpdateResources (Resource resource)
		{

		}
}
