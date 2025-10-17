using UnityEngine;

public static class LanguageSelector
{
    public static void SetLanguage(string langCode)
    {
        // Carga el nuevo idioma
        LocalizationManager.LoadLanguage(langCode);

        // Encuentra todos los LocalizedText (incluyendo los desactivados)
        LocalizedText[] localizedTexts = Object.FindObjectsByType<LocalizedText>(
            FindObjectsInactive.Include,
            FindObjectsSortMode.None
        );

        // Actualiza cada texto
        foreach (LocalizedText text in localizedTexts)
        {
            text.UpdateText();
        }

        Debug.Log($"Idioma cambiado a '{langCode}' ({localizedTexts.Length} textos actualizados)");
    }

    public static void SetLanguage(Language language)
    {
        switch (language)
        {
            case Language.Español:
                SetLanguage("es");
                break;
            case Language.English:
                SetLanguage("en");
                break;
            default:
                Debug.LogWarning($"Idioma no soportado: {language}. Usando Español por defecto.");
                SetLanguage("es");
                break;
        }
    }
}