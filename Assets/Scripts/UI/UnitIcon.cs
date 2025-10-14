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
    public UnitPO unitPO;
    private bool isInCourtyard;
    private bool isPointerOver;
    private TooltipObj tooltipItem;
    private TooltipObj tooltipUnit;

    public void SetUp(UnitPO unitPO, bool isInCourtyard)
    {
        this.unitPO = unitPO;
        this.isInCourtyard = isInCourtyard;

        leftBackground.color = Utils.GetColorByLevel(unitPO.Level);
        rightBackground.color = Utils.GetColorByRarity(ItemDBStatic.Get(unitPO.EquippedItem).Rarity);
        unitImage.sprite = ResourcePathDBStatic.Get(unitPO.UnitType);
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
        if (unitPO != null && !isPointerOver)
        {
            isPointerOver = true;
            ItemData item = ItemDBStatic.Get(unitPO.EquippedItem);

            tooltipUnit = new TooltipObj(unitPO.UnitName, unitPO.GetInfo(), TooltipType.UnitCourtyard, transform.position);
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
