using UnityEngine;
using TMPro;

public class UnitTooltip : MonoBehaviour
{
    public static UnitTooltip Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI statsText;
    private RectTransform tooltipRect;
    
    void Awake()
    {
        Instance = this;
        tooltipRect = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    public void ShowTooltip(UnitPO unit, Vector2 position)
    {
        nameText.text = unit.UnitType.ToString();
        statsText.text = unit.GetInfo();

        tooltipRect.position = position;
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}