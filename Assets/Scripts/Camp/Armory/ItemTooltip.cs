using UnityEngine;
using TMPro;

public class ItemTooltip : MonoBehaviour
{
    public static ItemTooltip Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI statsText;
    private RectTransform tooltipRect;
    
    void Awake()
    {
        Instance = this;
        tooltipRect = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    public void ShowTooltip(ItemData item, Vector2 position)
    {
        nameText.text = item.Name;
        statsText.text = item.GetInfo();

        tooltipRect.position = position;
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}