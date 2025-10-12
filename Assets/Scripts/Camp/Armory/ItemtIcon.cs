using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Image background;
    public Image iconImage;
    public TMP_Text quantityText;

    private ItemData itemData;
    private bool isPointerOver;


    public void SetUp(ItemData data, int quantity)
    {
        itemData = data;
        quantityText.text = quantity.ToString();

        // Cambiar color del marco según rareza
        background.color = Utils.GetColorByRarity(data.Rarity);
        iconImage.sprite = Resources.Load<Sprite>(ResourcePathDBStatic.Get(data.Item));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemData != null && !isPointerOver)
        {
            isPointerOver = true;
            Vector2 position = transform.position;
            position.y += 130;
            position.x += 100;
            ItemTooltip.Instance.ShowTooltip(itemData, position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
        ItemTooltip.Instance.HideTooltip();
    }

}
