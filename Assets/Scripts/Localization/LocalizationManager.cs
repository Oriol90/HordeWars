using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public static class LocalizationManager
{
    private static Dictionary<string, string> localizedTexts;
    private static string currentLanguage;

    private const string PREF_LANG = "selected_language";
    private const string DEFAULT_LANG = "es";

    static LocalizationManager()
    {
        string savedLang = PlayerPrefs.GetString(PREF_LANG, DEFAULT_LANG);
        LoadLanguage(savedLang);
    }

    public static void LoadLanguage(string langCode)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>($"Languages/{langCode}");
        if (jsonFile == null)
        {
            Debug.LogError($"No se encontró el archivo de idioma: {langCode}. Usando idioma por defecto.");
            langCode = DEFAULT_LANG;
            jsonFile = Resources.Load<TextAsset>($"Languages/{DEFAULT_LANG}");
        }

        localizedTexts = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonFile.text);
        currentLanguage = langCode;

        PlayerPrefs.SetString(PREF_LANG, currentLanguage);
        PlayerPrefs.Save();
    }

    public static string GetText(string key)
    {
        if (localizedTexts == null)
            LoadLanguage(DEFAULT_LANG);

        if (localizedTexts.TryGetValue(key, out string value))
            return value;

        Debug.LogWarning($"No se encontró la clave '{key}' en el idioma '{currentLanguage}'");
        return key;
    }

    public static string GetText(string key, params object[] args)
    {
        string rawText = GetText(key);
        return string.Format(rawText, args);
    }

    public static string CurrentLanguage => currentLanguage;
}
