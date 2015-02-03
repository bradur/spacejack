using UnityEngine;
using System.Collections;

public enum Resource{
    None,
    Dmitryivanovite,
    Sinoite,
    Alabandite,
    Credits,
    LifeSupport,
    Fuel,
    MiningSteps
};

public enum Tool
{
    None,
    BronzePickaxe,
    DiamondPickaxe,
    Drill,
    Laser
};

public enum JetPackUpgrade
{
    None,
    Lazy,
    TheBeast,
    Expert
}

public class ResourceManager : MonoBehaviour
{
    public int fuelAmount;
    public int maxFuelAmount;

    public int creditCount;

    public int[] resourceArray = new int[System.Enum.GetNames(typeof(Resource)).Length];

    public Tool currentTool;

    public int[] toolSteps = new int[System.Enum.GetNames(typeof(Tool)).Length];

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start ()
    {
        SetResourceCount(Resource.MiningSteps, GetMaxSteps());
    }

    void Update ()
    {
        
    }

    public void SetTool(Tool newTool)
    {
        currentTool = newTool;
        SetResourceCount(Resource.MiningSteps, GetMaxSteps());
    }

    public int GetMaxSteps()
    {
        return toolSteps[(int)currentTool];
    }

    public int GetResourceCount(Resource resource){
        return resourceArray[(int)resource];
    }

    public void SetResourceCount(Resource resource, int amount)
    {
        resourceArray[(int)resource] = amount;
    }

    public void UpdateResourceCount(Resource resource, int amount=0)
    {
        resourceArray[(int)resource] += amount;
    }

    public int FuelAmount {
        set{ this.fuelAmount = value;}
        get{ return this.fuelAmount;}
    }
}


