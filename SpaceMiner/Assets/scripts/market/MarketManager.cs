using UnityEngine;
using System.Collections;

public class MarketManager : MonoBehaviour {

    ResourceManager resourceManager;

    string maxFuel;

    public MarketButton[] marketButtons = new MarketButton[System.Enum.GetNames(typeof(Resource)).Length];
    public TextMesh[] resourceTexts = new TextMesh[System.Enum.GetNames(typeof(Resource)).Length];
    public GoalAvailability[] goals = new GoalAvailability[2];

    // Use this for initialization
    void Start () {
        resourceManager = GameObject.FindWithTag("resourceManager").GetComponent<ResourceManager>();

        for(int i = 0; i< marketButtons.Length; i++){
            UpdateResourceCount((Resource)i);
        }

        UpdateButtons();
        UpdateGoals();

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

    void UpdateGoals(){
        for(int i = 0; i < goals.Length; i++){
            goals[i].UpdateGoal(GetResourceCount(goals[i].goalType));
        }
    }

    public void UpdateResourceCount(Resource resource, int count = 0){
        resourceManager.UpdateResourceCount(resource, count);
        int newcount = resourceManager.GetResourceCount(resource);
        string text = newcount.ToString();

        if(resource == Resource.Fuel){
            text += " / " + maxFuel;
            // get spaceship info here later on
        }
        if(resource == Resource.Credits){
            text = "$"+text;
        }
        resourceTexts[(int)resource].text = text;
        if(count != 0){
            UpdateButtons();
            UpdateGoals();
        }
    }
}
