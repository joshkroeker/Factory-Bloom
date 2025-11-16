using UnityEngine;

[System.Serializable]
public class ResourceSlot
{
    public ResourceType resourceType;
    public int amount;
}


public enum MachineCategory { Miner, Conveyor, Assembler, Power, Utility }
public enum TerrainType { Unknown, Grass, Rock, Water }
public enum ResourceType { None, IronOre, Copper, Energy, Product }