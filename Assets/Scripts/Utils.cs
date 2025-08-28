

using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class Utils
{


    /// <summary>
    /// Convierte un Vector3Int (coordenadas de celda) a Vector3 (posición en el mundo, centrada en el tile).
    /// </summary>
    public static Vector3 CellToWorld(Vector3Int cellPos, Tilemap tilemap)
    {
        Vector3 worldPos = tilemap.CellToWorld(cellPos);
        worldPos += tilemap.cellSize / 2; // centra en el tile
        return worldPos;
    }

    /// <summary>
    /// Convierte un Vector3 (posición en el mundo) a Vector3Int (coordenadas de celda en el tilemap).
    /// </summary>
    public static Vector3Int WorldToCell(Vector3 worldPos, Tilemap tilemap)
    {
        return tilemap.WorldToCell(worldPos);
    }


    public static TileData TileNameToTileData(string longTileName, Vector3Int pos)
    {
        TileData tileData = new TileData
                {
                    tileName = longTileName,
                    fogState = FogState.Unexplored,
                    x = pos.x,
                    y = pos.y,
                    z = pos.z
                };

        switch (longTileName)
        {

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_0":
                tileData.biome = Biome.Beach;
                tileData.cost = 2;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_1":
                tileData.biome = Biome.Beach;
                tileData.cost = 2;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_2":
                tileData.biome = Biome.Grass;
                tileData.cost = 1;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_3":
                tileData.biome = Biome.Grass;
                tileData.cost = 1;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_4":
                tileData.biome = Biome.Grass;
                tileData.cost = 1;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_5":
                tileData.biome = Biome.Grass;
                tileData.cost = 1;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_6":
                tileData.biome = Biome.Mountain;
                tileData.cost = 5;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_7":
                tileData.biome = Biome.Mountain;
                tileData.cost = 5;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_8":
                tileData.biome = Biome.Forrest;
                tileData.cost = 3;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_9":
                tileData.biome = Biome.Mountain;
                tileData.cost = 5;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_10":
                tileData.biome = Biome.River;
                tileData.cost = 7;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_11":
                tileData.biome = Biome.River;
                tileData.cost = 7;
                break;

            default:
                tileData.biome = Biome.Grass;
                tileData.cost = 1;
                break;
        }
        return tileData;
    }

}