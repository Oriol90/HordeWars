

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


    public static int GetTileName(string longTileName)
    {
        string tileName = "";
        int cost = 1;

        switch (longTileName)
        {

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_0":
                tileName = GC.TILE_SAND_1;
                cost = 2;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_1":
                tileName = GC.TILE_SAND_2;
                cost = 2;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_2":
                tileName = GC.TILE_GRASS_1;
                cost = 1;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_3":
                tileName = GC.TILE_GRASS_2;
                cost = 1;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_4":
                tileName = GC.TILE_GRASS_3;
                cost = 1;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_5":
                tileName = GC.TILE_GRASS_4;
                cost = 1;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_6":
                tileName = GC.TILE_MOUNTAIN_1;
                cost = 10;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_7":
                tileName = GC.TILE_MOUNTAIN_2;
                cost = 10;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_8":
                tileName = GC.TILE_FORREST;
                cost = 4;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_9":
                tileName = GC.TILE_MOUNTAIN_3;
                cost = 10;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_10":
                tileName = GC.TILE_LAVA;
                cost = 20;
                break;

            case "Terrain_1_-_Flat_-_Black_Outline_1px_-_128x128-removebg-preview_11":
                tileName = GC.TILE_WATER;
                cost = 5;
                break;
        }
        return cost;
    }

}