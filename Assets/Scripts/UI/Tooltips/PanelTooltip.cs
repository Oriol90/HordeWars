using UnityEngine;
using TMPro;

public class PanelTooltip : MonoBehaviour
{
    public static PanelTooltip Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI statsText;

    private RectTransform tooltipRect;
    
    void Awake()
    {
        Instance = this;
        tooltipRect = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    public void ShowTooltip(TooltipObj tooltipObj)
    {
        nameText.text = tooltipObj.title;
        statsText.text = tooltipObj.body;

        tooltipRect.position = tooltipObj.finalPosition;
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}