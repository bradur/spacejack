using UnityEngine;
using System.Collections;

public class MarketManager : MonoBehaviour {

    ResourceManager resourceManager;

    string maxFuel;

    public GameObject[] buttonObjects = new GameObject[System.Enum.GetNames(typeof(Resource)).Length];
    MarketButton[] marketButtons = new MarketButton[System.Enum.GetNames(typeof(Resource)).Length];
    public GameObject[] counterObjects = new GameObject[System.Enum.GetNames(typeof(Resource)).Length];
    TextMesh[] resourceTexts = new TextMesh[System.Enum.GetNames(typeof(Resource)).Length];

    // Use this for initialization
    void Start () {
        resourceManager = GameObject.FindWithTag("resourceManager").GetComponent<ResourceManager>();

        for(int i = 0; i< counterObjects.Length; i++){
            resourceTexts[i] = counterObjects[i].GetComponent<TextMesh>();
            UpdateResourceCount((Resource)i);
        }

        for(int i = 0; i < buttonObjects.Length; i++){
            marketButtons[i] = buttonObjects[i].GetComponent<MarketButton>();
        }

        UpdateButtons();

        maxFuel = resourceManager.maxFuelAmount.ToString();
    }

    void UpdateButtons(){
        for(int i = 0; i < marketButtons.Length; i++)
        {
            marketButtons[i].CheckAvailability(GetResourceCount(marketButtons[i].costType));
        }
    }

    public int GetResourceCount(Resource resource){
        return resourceManager.GetResourceCount(resource);
    }

    public void UpdateResourceCount(Resource resource, int count = 0){
        resourceManager.UpdateResourceCount(resource, count);
        string text = resourceManager.GetResourceCount(resource).ToString();
        if(resource == Resource.Fuel){
            text += " / " + maxFuel;
        }
        if(resource == Resource.Credits){
            text = "$"+text;
        }
        resourceTexts[(int)resource].text = text;
        if(count != 0){
            UpdateButtons();
        }
    }
}
