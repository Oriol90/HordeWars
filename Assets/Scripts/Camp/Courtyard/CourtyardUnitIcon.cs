using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CourtyardUnitIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image leftBackground;
    public Image rightBackground;
    public Image unitImage;
    public Image arrowUpImage;
    public Image arrowDownImage;

    [HideInInspector]
    public UnitPO unitPO;
    public bool isInCourtyard;
    private bool isPointerOver;

    public void SetUp(UnitPO unitPO, bool isInCourtyard)
    {
        this.unitPO = unitPO;
        this.isInCourtyard = isInCourtyard;

        leftBackground.color = Utils.GetColorByLevel(unitPO.Level);
        rightBackground.color = Utils.GetColorByRarity(ItemDBStatic.Get(unitPO.EquippedItem).Rarity);
        unitImage.sprite = unitPO.ImageIcon;
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

            Vector2 positionUnit = transform.position;
            positionUnit.y += 125;
            positionUnit.x += 100;

            Vector2 positionItem = transform.position;
            positionItem.y += 125;
            positionItem.x += 350;

            UnitTooltip.Instance.ShowTooltip(unitPO, positionUnit);
            ItemTooltip.Instance.ShowTooltip(ItemDBStatic.Get(unitPO.EquippedItem), positionItem);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
        UnitTooltip.Instance.HideTooltip();
        ItemTooltip.Instance.HideTooltip();
    }
}
