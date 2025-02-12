using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // Cambiar a la escena principal del juego
        SceneManager.LoadScene(GC.SCENE_RACE_SELECTION); // Asegúrate de que "GameScene" sea el nombre de tu escena principal
    }

    public void OpenOptions()
    {
        // Abrir el menú de opciones (puedes implementar esta funcionalidad más tarde)
        Debug.Log("Options menu not implemented yet.");
    }

    public void ExitGame()
    {
        // Salir del juego
        Debug.Log("Exiting the game...");
        Application.Quit();
    }
}
