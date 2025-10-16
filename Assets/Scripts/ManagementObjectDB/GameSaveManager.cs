using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

public static class GameSaveManager
{
    private static string saveDirectory => Path.Combine(Application.persistentDataPath, GC.SAVE_DIRECTORY);

    public static void Save(object data, DataType dataType)
    {
        if (!Directory.Exists(saveDirectory))
            Directory.CreateDirectory(saveDirectory);

        string fullPath = Path.Combine(saveDirectory, dataType.ToString());
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);

        File.WriteAllText(fullPath, json);
        Debug.Log($"{dataType} saved.");
    }

    public static T Load<T>(DataType dataType)
    {
        string fullPath = Path.Combine(saveDirectory, dataType.ToString());

        if (!File.Exists(fullPath))
        {
            Debug.LogWarning($"[LoadGame] No se encontró archivo en: {fullPath}");
        }

        string json = File.ReadAllText(fullPath);
        Debug.Log($"{dataType} loaded.");
        return JsonConvert.DeserializeObject<T>(json);
    }

    public static void SaveTalents(List<TalentData> listTalents)
    {
        Save(listTalents, DataType.TalentData);
    }

    public static Vector3Int LoadHeroPos()

    {
        HeroData heroData = Load<HeroData>(DataType.HeroData);
        return heroData.heroPos;
    }

    public static void SaveHeroPos(Vector3Int heroPos)
    {
        HeroData heroData = Load<HeroData>(DataType.HeroData);
        heroData.heroPos = heroPos;
        Save(heroData, DataType.HeroData);
    }
}