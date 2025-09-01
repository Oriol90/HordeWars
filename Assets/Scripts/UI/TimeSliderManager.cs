using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeSliderManager : MonoBehaviour
{
    public Slider timeSlider;          // Referencia al slider
    public TextMeshProUGUI timeText;   // Texto para mostrar la hora
    private float currentTime = 0f;    // Almacena la hora actual

    private void Start()
    {
        currentTime = timeSlider.value;  // Iniciar desde la hora del slider
        UpdateTimeDisplay(currentTime);
    }

    private void Update()
    {
        // Avanzar el tiempo
        currentTime += GC.TIME_SPEED * Time.deltaTime;
        
        // Reiniciar el ciclo a 0 si pasa las 24 horas
        if (currentTime >= 24f)
        {
            currentTime = 0f;
        }

        // Actualizar el slider y el texto
        timeSlider.value = currentTime;
        UpdateTimeDisplay(currentTime);
    }

    private void UpdateTimeDisplay(float value)
    {
        int hours = Mathf.FloorToInt(value);
        int minutes = Mathf.FloorToInt((value - hours) * 60);
        if(hours < 17) hours = hours + 7;
        else hours -= 17;
        string timeString = string.Format("{0:00}:{1:00}", hours, minutes);
        timeText.text = timeString;
    }
}
