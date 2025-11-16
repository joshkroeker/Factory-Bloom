using System;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Handles player input for building placement, checks tile validity, previews placement ghosts, and commits placement to the world.
/// </summary>
public class PlacementManager : MonoBehaviour
{
    [SerializeField] WorldGrid grid;
    [SerializeField] GameObject previewInstance;
    
    MachineBlueprint currentBlueprint;
    bool isPlacing;


    void StartPlacement(MachineBlueprint blueprint) { }
    void UpdatePlacement(Vector3 cursorPos) {}
    void ConfirmPlacement(){}
    void CancelPlacement(){}

    bool ValidatePlacement(GridCell tile)
    {
        return false;
    }
}