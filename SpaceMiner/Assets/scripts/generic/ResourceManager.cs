using UnityEngine;
using System.Collections;

public enum Mineral
{
    Sinoite,
    Dmitryivanovite,
    Alabandite
};

public enum Tool
{
    BronzePickaxe,
    DiamondPickaxe,
    Drill,
    Laser
};

public enum JetPackUpgrade
{
    Lazy,
    TheBeast,
    Expert
}

public class ResourceManager : MonoBehaviour
{
    public int fuelAmount;
    public int maxFuelAmount;

    public int creditCount;

    public int[] mineralArray = new int[System.Enum.GetNames(typeof(Mineral)).Length];

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start ()
    {
    }

    void Update ()
    {
        
    }

    public int GetMineralCount(Mineral mineral){
        return mineralArray[(int)mineral];
    }

    public void SetMineralCount(Mineral mineral, int count){
        mineralArray[(int)mineral] += count;
    }

    public void GiveMinerals (Mineral mineralType, int amount)
    {
        mineralArray[(int)mineralType] += amount;
        /*
        switch (mineralType) {
        case Mineral.Dmitryivanovite:
            dmitryivanoviteAmount += amount;
            break;

        case Mineral.Sinoite:
            sinoiteAmount += amount;
            break;
        }*/
    }

    public int FuelAmount {
        set{ this.fuelAmount = value;}
        get{ return this.fuelAmount;}
    }
}


