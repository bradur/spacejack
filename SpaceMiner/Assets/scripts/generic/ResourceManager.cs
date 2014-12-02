using UnityEngine;
using System.Collections;

public enum Resource{
    None,
    Dmitryivanovite,
    Sinoite,
    Alabandite,
    Credits,
    LifeSupport,
    Fuel
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

public enum ResourceType{
    None,
    Dmitryivanovite,
    Sinoite,
    Alabandite,
    Credits,
    LifeSupport,
    Fuel
};

public class ResourceManager : MonoBehaviour
{
    public int fuelAmount;
    public int maxFuelAmount;

    public int creditCount;

    public int[] resourceArray = new int[System.Enum.GetNames(typeof(Resource)).Length];

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start ()
    {
    }

    void Update ()
    {
        
    }

    public int GetResourceCount(Resource resource){
        return resourceArray[(int)resource];
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


