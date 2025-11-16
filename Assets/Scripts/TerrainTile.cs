using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TerrainTile", menuName = "Factory Bloom/Terrain Tile")]
public class TerrainTile : Tile
{
    public TerrainType terrainType;
    public bool isBuildable = true;
}
