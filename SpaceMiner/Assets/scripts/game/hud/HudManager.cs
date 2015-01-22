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

        public void UpdateResourceCount(Resource resource, int amount)
        {
            resourceManager.UpdateResourceCount(resource, amount);
            UpdateHud();
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
            for (int i = 0; i < indicatorList.Length; i++)
            {
                    if (indicatorList[i] == null)
                    {
                        // do nothing
                        print(indicatorList[i] + ": " + i);
                    }
                    else
                    {
                        Resource indicatorsResource = indicatorList[i].GetComponent<Indicator>().resource;
                        print(indicatorsResource);
                        if (indicatorsResource == Resource.Fuel)
                        {
                            
                            indicatorList[i].GetComponent<TextMesh>().text = "" + resourceManager.GetResourceCount(indicatorsResource);
                        }
                        else
                        {
                            print(resourceManager.GetResourceCount(indicatorsResource));
                            indicatorList[i].GetComponent<TextMesh>().text = "" + resourceManager.GetResourceCount(indicatorsResource);
                        }
                    }
				}
		}
}
