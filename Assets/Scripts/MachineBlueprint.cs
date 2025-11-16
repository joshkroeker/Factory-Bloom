using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Machine_Blueprint", menuName = "Blueprints/Machine Blueprint")]
public class MachineBlueprint : ScriptableObject
{
    [Header("Identification")]
    public GUID id;
    public MachineCategory category;
    public Sprite spriteIcon;

    [Header("Placement Properties")]
    public GameObject prefab;
    public Vector2Int size = Vector2Int.one;
    public List<TerrainType> allowedTerrain;

    [Header("Construction")]
    public Dictionary<ResourceType, int> buildCost = new();
    public float energyCost;
    public float processingTime;

    [Header("Production")]
    public List<ResourceSlot> inputSlots;
    public List<ResourceSlot> outputSlots;

    [Header("Visuals & Audio")]
    public AudioClip buildSound;
    public AudioClip activeLoopSound;
    public ParticleSystem effectPrefab;
}
