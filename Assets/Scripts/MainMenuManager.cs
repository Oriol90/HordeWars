using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public TMP_Dropdown languageDropdown;
    public Button startButton;
    public Button talentTreeButton;
    public Button exitButton;

    public void Start()
    {
        
        setUpElements();
    }

    private void setUpElements()
    {
        languageDropdown.ClearOptions();
        languageDropdown.AddOptions(new List<string>(Enum.GetNames(typeof(Language))));
        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);

        startButton.onClick.AddListener(() => StartGame());
        startButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationManager.GetText(TextKeys.PLAY);

        talentTreeButton.onClick.AddListener(() => TalentTree());
        talentTreeButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationManager.GetText(TextKeys.TALENT_TREE);

        exitButton.onClick.AddListener(() => ExitGame());
        exitButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationManager.GetText(TextKeys.EXIT);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(GC.SCENE_RACE_SELECTION); 
    }

    public void TalentTree()
    {
        SceneManager.LoadScene(GC.SCENE_TALENT_TREE); 
    }

    public void OpenOptions()
    {
        // Abrir el menú de opciones (puedes implementar esta funcionalidad más tarde)
        Debug.Log("Options menu not implemented yet.");
    }

    private void OnLanguageChanged(int index)
    {
        Language selectedLanguage = (Language)Enum.Parse(typeof(Language), languageDropdown.options[index].text);
        LanguageSelector.SetLanguage(selectedLanguage);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting the game...");
        Application.Quit();
    }
}