using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceSelection : MonoBehaviour
{
    public RawImage backgroundImage;
    public Texture humanBackground;
    public Texture elfBackground;
    public Texture orcBackground;

    private string selectedRace = "Human"; // Valor por defecto

    void Start()
    {
        if (backgroundImage == null)
        {
            backgroundImage = GameObject.FindFirstObjectByType<RawImage>();
        }

        if (backgroundImage == null)
        {
            Debug.LogError("❌ Background Image is not assigned and could not be found in the scene!");
            return;
        }

        if (humanBackground == null || elfBackground == null || orcBackground == null)
        {
            Debug.LogError("❌ One or more textures are not assigned!");
            return;
        }

        backgroundImage.texture = humanBackground;
    }

    public void SelectHuman()
    {
        backgroundImage.texture = humanBackground;
        selectedRace = GC.RACE_HUMAN;
    }

    public void SelectElf()
    {
        backgroundImage.texture = elfBackground;
        selectedRace = GC.RACE_ELF;
    }

    public void SelectOrc()
    {
        backgroundImage.texture = orcBackground;
        selectedRace = GC.RACE_ORC;
    }

    public void GoToHeroSelection()
    {
        PlayerPrefs.SetString(GC.PLAYER_PREFS_SELECTED_RACE, selectedRace);
        PlayerPrefs.Save();
        SceneManager.LoadScene(GC.SCENE_HEROE_SELECTION); // Asegúrate de que la escena exista en Build Settings
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene(GC.SCENE_MAIN_MENU);
    }
}
