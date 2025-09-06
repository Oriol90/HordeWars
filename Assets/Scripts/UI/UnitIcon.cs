using UnityEngine;
using UnityEngine.EventSystems;

public class UnitIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private UnitPO unitData;
    private bool isPointerOver;

    public void SetUnitData(UnitPO data)
    {
        unitData = data;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (unitData != null && !isPointerOver)
        {
            isPointerOver = true;
            Vector2 position = transform.position;
            position.y += 200f; // Ajusta este valor según necesites
            UnitTooltip.Instance.ShowTooltip(unitData, position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
        UnitTooltip.Instance.HideTooltip();
    }
}