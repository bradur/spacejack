using UnityEngine;
using System.Collections;

public class MarketManager : MonoBehaviour {

    ResourceManager resourceManager;

    public GameObject fuelCountObject;
    TextMesh fuelCountText;
    int fuelCount;
    string maxFuel;

    public GameObject creditCountObject;
    TextMesh creditCountText;
    int creditCount;

    public int[] mineralArray = new int[System.Enum.GetNames(typeof(Mineral)).Length];
    public GameObject[] mineralObjects = new GameObject[System.Enum.GetNames(typeof(Mineral)).Length];
    TextMesh[] mineralTexts = new TextMesh[System.Enum.GetNames(typeof(Mineral)).Length];


    // Use this for initialization
    void Start () {
        resourceManager = GameObject.FindWithTag("resourceManager").GetComponent<ResourceManager>();
        fuelCountText = fuelCountObject.GetComponent<TextMesh>();
        creditCountText = creditCountObject.GetComponent<TextMesh>();

        //resourceManager.GetMineralCount(Mineral.Sinoite);
        //resourceManager.GetMineralCount(Mineral.Dmitryivanovite);
        //resourceManager.GetMineralCount(Mineral.Alabandite);

        for(int i = 0;i < mineralArray.Length; i++){
            mineralArray[i] = resourceManager.GetMineralCount((Mineral)i);
        }
        for(int i = 0; i< mineralObjects.Length; i++){
            mineralTexts[i] = mineralObjects[i].GetComponent<TextMesh>();
            UpdateMineralCount((Mineral)i);
        }

        creditCount = resourceManager.creditCount;
        fuelCount = resourceManager.fuelAmount;
        maxFuel = resourceManager.maxFuelAmount.ToString();
        UpdateCreditCount();
        UpdateFuelCount();


    }
    
    // Update is called once per frame
    void Update () {
    
    }

    public void UpdateMineralCount(Mineral mineral, int count=0){
        mineralArray[(int)mineral] += count;
        resourceManager.SetMineralCount(mineral, count);
        print(mineral + ": " + resourceManager.GetMineralCount(mineral));
        mineralTexts[(int)mineral].text = resourceManager.GetMineralCount(mineral).ToString();
    }

    public void UpdateCreditCount(int newCount=0){
        creditCount += newCount;
        creditCountText.text = "$" + creditCount.ToString();
        resourceManager.creditCount = creditCount;
    }

    public void UpdateFuelCount(int newCount=0){
        fuelCount += newCount;
        fuelCountText.text = fuelCount.ToString() + " / " + maxFuel;
        print(maxFuel);
        resourceManager.fuelAmount = fuelCount;
    }
}
