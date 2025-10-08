using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour
{

    public Image background;
    public Image iconImage;
    public TMP_Text quantityText;

    private ItemData itemData;

    public void SetUp(ItemData data, int quantity)
    {
        itemData = data;
        quantityText.text = quantity.ToString();

        // Cambiar color del marco según rareza
        background.color = GetColorByRarity(data.Rarity);
        iconImage.sprite = Resources.Load<Sprite>(GC.ITEM_SPRITE_PATHS[data.Item]);
    }

    private Color GetColorByRarity(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.Common: return new Color32(255, 255, 255, 255);     // blanco
            case Rarity.Uncommon: return new Color32(76, 175, 80, 255);     // verde
            case Rarity.Rare: return new Color32(33, 150, 243, 255);        // azul
            case Rarity.Epic: return new Color32(156, 39, 176, 255);        // morado
            case Rarity.Mythic: return new Color32(255, 99, 71, 255);       // rojo claro
            case Rarity.Celestial: return new Color32(255, 215, 0, 255);    // dorado
            default: return Color.white;
        }
    }

    public void FillInfoItem()
    {
        ItemTooltip.Instance.FillTooltip(itemData);
    }
}
