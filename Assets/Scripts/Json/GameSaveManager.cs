using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

public static class GameSaveManager
{
    private static string saveDirectory => Path.Combine(Application.persistentDataPath, GC.SAVE_DIRECTORY);
    private static GameData data = new GameData();

    public static void SaveGame(GameData data)
    {
        if (!Directory.Exists(saveDirectory))
            Directory.CreateDirectory(saveDirectory);

        string fullPath = Path.Combine(saveDirectory, GC.SAVE_FILE_NAME);
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);

        File.WriteAllText(fullPath, json);
        Debug.Log($"[SaveGame] Guardado en: {fullPath}");
    }

    public static GameData LoadGame()
    {
        string fullPath = Path.Combine(saveDirectory, GC.SAVE_FILE_NAME);

        if (!File.Exists(fullPath))
        {
            Debug.LogWarning($"[LoadGame] No se encontró archivo en: {fullPath}");
        }

        string json = File.ReadAllText(fullPath);
        return JsonConvert.DeserializeObject<GameData>(json);
    }

    public static List<Talent> LoadTalents()
    {
        GameData gameData = LoadGame();
        return gameData.talents;
    }

    public static void SaveTalents(List<Talent> listTalents)
    {
        data = LoadGame();
        data.talents = listTalents;
        SaveGame(data);
    }

    public static Vector3Int LoadHeroPos()
    {
        GameData gameData = LoadGame();
        return gameData.heroPos;
    }

    public static void SaveHeroPos(Vector3Int heroPos)
    {
        data = LoadGame();
        data.heroPos = heroPos;
        SaveGame(data);
    }
}