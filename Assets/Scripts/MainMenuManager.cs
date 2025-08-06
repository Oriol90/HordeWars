using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

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

    public void ExitGame()
    {
        Debug.Log("Exiting the game...");
        Application.Quit();
    }
}