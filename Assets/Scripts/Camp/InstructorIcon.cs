using UnityEngine;
using UnityEngine.UI;

public class InstructorIcon : MonoBehaviour
{
    public InstructorData instructor;   // Los datos de este instructor
    public Button button;         // El botón asociado

    private void Awake()
    {
        // Asignar listener
        if (button == null) button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void Initialize(InstructorData instructor)
    {
        this.instructor = instructor;

        // if (portraitImage != null && data.Stats != null) 
        // {
        //     // Ejemplo: si dentro de Stats tienes un sprite
        //     portraitImage.sprite = data.Stats.Portrait;
        // }

        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        // Avisar al panel para que se actualice
        InstructorPanel.Instance.ShowInstructor(instructor);
    }
}
