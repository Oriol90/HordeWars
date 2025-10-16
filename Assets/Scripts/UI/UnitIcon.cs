using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image leftBackground;
    public Image rightBackground;
    public Image unitImage;
    public Image arrowUpImage;
    public Image arrowDownImage;
    public PanelTooltip unitTooltipPanel;
    public PanelTooltip itemTooltipPanel;

    [HideInInspector]
    public UnitData unitData;
    private bool isInCourtyard;
    private bool isPointerOver;
    private TooltipObj tooltipItem;
    private TooltipObj tooltipUnit;

    public void SetUp(UnitData unitData, bool isInCourtyard)
    {
        this.unitData = unitData;
        this.isInCourtyard = isInCourtyard;

        leftBackground.color = Utils.GetColorByLevel(unitData.level);
        rightBackground.color = Utils.GetColorByRarity(ItemDBStatic.Get(unitData.equippedItem).Rarity);
        unitImage.sprite = ResourcePathDBStatic.Get(unitData.unitType);
    }

    public void ToggleArrow()
    {
        if (isInCourtyard) ToggleGO(arrowDownImage.gameObject);
        else ToggleGO(arrowUpImage.gameObject);
    }

    private void ToggleGO(GameObject go)
    {
        if (go.activeSelf) go.SetActive(false);
        else go.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (unitData != null && !isPointerOver)
        {
            isPointerOver = true;
            ItemData item = ItemDBStatic.Get(unitData.equippedItem);

            tooltipUnit = new TooltipObj(unitData.unitName, unitData.GetInfo(), TooltipType.UnitCourtyard, transform.position);
            tooltipItem = new TooltipObj(item.Name, item.GetInfo(), TooltipType.ItemCourtyard, transform.position);

            unitTooltipPanel.ShowTooltip(tooltipUnit);
            itemTooltipPanel.ShowTooltip(tooltipItem);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
        unitTooltipPanel.HideTooltip();
        itemTooltipPanel.HideTooltip();
    }
}
