using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Image background;
    public Image iconImage;
    public TMP_Text quantityText;
    public PanelTooltip itemTooltipPanel;

    private ItemData itemData;
    private bool isPointerOver;
    public TooltipObj tooltipItem;


    public void SetUp(ItemData data, int quantity)
    {
        itemData = data;
        quantityText.text = quantity.ToString();

        // Cambiar color del marco según rareza
        background.color = Utils.GetColorByRarity(data.Rarity);
        iconImage.sprite = ResourcePathDBStatic.Get(data.Item);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemData != null && !isPointerOver)
        {
            isPointerOver = true;
            tooltipItem = new TooltipObj(itemData.Name, itemData.GetInfo(), TooltipType.ItemArmory, transform.position);
            itemTooltipPanel.ShowTooltip(tooltipItem);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
        itemTooltipPanel.HideTooltip();
    }
}
