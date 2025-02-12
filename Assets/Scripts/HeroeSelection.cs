using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroSelection : MonoBehaviour
{
    public RawImage backgroundImage;
    public Texture humanBackground;
    public Texture elfBackground;
    public Texture orcBackground;

    void Start()
    {
        if (backgroundImage == null)
        {
            backgroundImage = GameObject.FindFirstObjectByType<RawImage>();
        }

        string selectedRace = PlayerPrefs.GetString(GC.PLAYER_PREFS_SELECTED_RACE); // Recupera la raza

        switch(selectedRace){
            case GC.RACE_HUMAN:
                backgroundImage.texture = humanBackground;
            break;

            case GC.RACE_ORC:
                backgroundImage.texture = orcBackground;
            break;

            case GC.RACE_ELF:
                backgroundImage.texture = elfBackground;
            break;
        }
    }

    public void BackToRaceSelection(){
        SceneManager.LoadScene(GC.SCENE_RACE_SELECTION);
    }
}
