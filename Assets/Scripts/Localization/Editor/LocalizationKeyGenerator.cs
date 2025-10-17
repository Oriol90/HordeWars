using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;

public class LocalizationKeyGenerator
{
    private const string OutputPath = "Assets/Scripts/Localization/TextKeys.cs";
    private const string LanguageFolder = "Assets/Resources/Languages";

    [MenuItem("Tools/Localization/Generate TextKeys")]
    public static void GenerateTextKeys()
    {
        if (!Directory.Exists(LanguageFolder))
        {
            Debug.LogError($"No se encontró la carpeta: {LanguageFolder}");
            return;
        }

        var keys = new HashSet<string>();

        foreach (var file in Directory.GetFiles(LanguageFolder, "*.json"))
        {
            string json = File.ReadAllText(file);
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            foreach (var key in dict.Keys)
                keys.Add(key);
        }

        string[] sortedKeys = keys.OrderBy(k => k).ToArray();

        string fileContent = "public static class TextKeys\n{\n";
        foreach (var key in sortedKeys)
        {
            fileContent += $"    public const string {key} = \"{key}\";\n";
        }
        fileContent += "}";

        File.WriteAllText(OutputPath, fileContent);
        AssetDatabase.Refresh();

        Debug.Log($"✅ TextKeys.cs generado con {sortedKeys.Length} claves.");
    }
}
