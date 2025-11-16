using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class WorldGrid : MonoBehaviour
{
    [Header("Tilemap References")]
    public Tilemap terrainTilemap;
    public Tilemap resourceTilemap;
    public Tilemap decorationTilemap;
    
    GameGrid gridData;

    void Awake()
    {
        gridData = new GameGrid(
            terrainTilemap.cellBounds.xMax, 
            terrainTilemap.cellBounds.yMax,
            terrainTilemap);
    }

    public GridCell GetCellByVector3(Vector3 position)
    {
        var conversion = new Vector2Int(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.z));
        return gridData.GetTile(conversion);
    }
    
    public GridCell GetCellByCoords(int x, int y)
    {
        return gridData.GetTile(new Vector2Int(x, y));
    }

    public bool IsOccupied(Vector2Int position) =>
        gridData.tiles.ContainsKey(position) && gridData.tiles[position].isOccupied;
    
    TerrainType ResolveTerrainType(TileBase tile)
    {
        if (terrainTilemap.ContainsTile(tile))
        {
            
        }
        
        return TerrainType.Grass; // default case
    }
    
    ResourceType ResolveResourceType(TileBase tile)
    {
        if (resourceTilemap.ContainsTile(tile))
        {
            
        }
        
        return ResourceType.None; // default case
    }
}

public class GameGrid
{
    int width;
    int height;

    public readonly Dictionary<Vector2Int, GridCell> tiles;

    public GameGrid(int width, int height, Tilemap terrainTilemap, float cellSize = 1f)
    {
        this.width = width;
        this.height = height;
        
        tiles = new Dictionary<Vector2Int, GridCell>();

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                var cellPos = new Vector3Int(x, y, 0);
                var rawTile = terrainTilemap.GetTile(cellPos);

                if (rawTile == null)
                    continue;

                var terrainTile = rawTile as TerrainTile;
                
                var t = new GridCell(
                    x,y, 
                    false, 
                    !terrainTile ? TerrainType.Unknown : terrainTile.terrainType);
                tiles.Add(t.cellPosition, t);
            }
        }
    }

    public GridCell GetTile(Vector2Int cellPosition)
    {
        return tiles[cellPosition];
    }

    public Vector2Int GetCellPosition(GridCell tile)
    {
        return tile.cellPosition;
    }
}

public class GridCell
{
    public int x;
    public int y;
    public Vector2 cellCenter;
    public Vector2Int cellPosition;
    public readonly bool isOccupied;
    // entityRef : PlaceableEntity

    public TerrainType Terrain { get; private set; }

    public GridCell(int x, int y, float cellSize = 1f)
    {
        this.x = x;
        this.y = y;

        InitializeTileData(x, y, cellSize);
    }

    public GridCell(int x, int y, bool isOccupied, TerrainType terrainType, float cellSize = 1f)
    {
        this.x = x;
        this.y = y;
        this.isOccupied = isOccupied;
        Terrain = terrainType;

        InitializeTileData(x, y, cellSize);
    }

    void InitializeTileData(int width, int height, float cellSize)
    {
        cellCenter = new Vector2(
            Mathf.RoundToInt(width + cellSize / 2f), 
            Mathf.RoundToInt(height + cellSize / 2f));

        cellPosition = new Vector2Int(width, height);
    }

    public void SetTerrainType(TerrainType terrainType)
    {
        Terrain = terrainType;
    }
}