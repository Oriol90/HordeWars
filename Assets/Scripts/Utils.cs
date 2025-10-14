

using System;
using System.Text;
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


    public static GroundTileData GroundTileNameToGroundTileData(string longTileName, Vector3Int pos)
    {
        GroundTileData tileData = new GroundTileData
        {
            tileName = longTileName,
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

    public static FogTileData FogTileVisibilityToFogTileData(String longTileName, Vector3Int pos)
    {
        FogTileData tileData = new FogTileData
        {
            x = pos.x,
            y = pos.y,
            z = pos.z
        };

        switch (longTileName)
        {

            case GC.FOG_TILE_NAME:
                tileData.tileName = longTileName;
                tileData.fogState = FogState.Unexplored;
                break;

            case GC.SHADOW_TILE_NAME:
                tileData.tileName = longTileName;
                tileData.fogState = FogState.Explored;
                break;

            default:
                tileData.fogState = FogState.Visible;
                break;
        }
        return tileData;
    }

    public static Unit UnitTypeToUnit(UnitType unitType, GameObject go)
    {
        Unit unit;
        switch (unitType)
        {
            case UnitType.GirlKnight:
                unit = go.GetComponent<GirlKnight>();
                break;
            case UnitType.LeafArcher:
                unit = go.GetComponent<LeafArcher>();
                break;
            case UnitType.Archer:
                unit = go.GetComponent<Archer>();
                break;
            default:
                unit = null;
                break;
        }
        return unit;
    }

    public static Color GetColorByRarity(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.Common: return new Color32(255, 255, 255, 255);     // blanco
            case Rarity.Uncommon: return new Color32(76, 175, 80, 255);     // verde
            case Rarity.Rare: return new Color32(33, 150, 243, 255);        // azul
            case Rarity.Epic: return new Color32(156, 39, 176, 255);        // morado
            case Rarity.Mythic: return new Color32(255, 99, 71, 255);       // rojo claro
            case Rarity.Celestial: return new Color32(255, 215, 0, 255);    // dorado
            default: return Color.gray;
        }
    }

    public static Color GetColorByLevel(int exp)
    {
        switch (exp)
        {
            case 1: return new Color32(255, 255, 255, 255);    // blanco
            case 2: return new Color32(76, 175, 80, 255);       // verde
            case 3: return new Color32(33, 150, 243, 255);      // azul
            case 4: return new Color32(156, 39, 176, 255);      // morado
            case 5: return new Color32(255, 99, 71, 255);       // rojo claro
            case 6: return new Color32(255, 215, 0, 255);       // dorado
            default: return Color.gray;
        }
    }

    public static int CreateRandomNumber(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    public static T GetRandomEnumValue<T>() where T : Enum
    {
        Array values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }

    public static string ShowTime(int timeInHours)
    {
        int day = timeInHours / 24;
        int hour = timeInHours % 24;
        StringBuilder sb = new StringBuilder();
        sb.Append($"Day {day + 1}, ");
        if (hour < 10) sb.Append("0");
        sb.Append($"{hour}:00");

        return sb.ToString();
    }

    public static string BeautifyTime(int timeInHours)
    {
        int day = timeInHours / 24;
        int hour = timeInHours % 24;
        StringBuilder sb = new StringBuilder();
        
        if (day > 0) sb.Append($"{day} day{(day > 1 ? "s" : "")}");
        if (hour > 0)   
        {
            if (sb.Length > 0) sb.Append(" and ");
            sb.Append($"{hour} hour{(hour > 1 ? "s" : "")}");
        }   
        return sb.ToString();
    }
}