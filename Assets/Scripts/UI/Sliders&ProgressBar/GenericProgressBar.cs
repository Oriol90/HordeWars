using UnityEngine;
using UnityEngine.UI;

public class GenericProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMaxValue(float maxValue)
    {
        slider.maxValue = maxValue;
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }

    public void SetMinValue(float minValue)
    {
        slider.minValue = minValue;
    }

    public void SetProgress(float current, float max)
    {
        slider.value = current / max;
    }
}
