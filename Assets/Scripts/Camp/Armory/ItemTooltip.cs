using UnityEngine;
using TMPro;

public class ItemTooltip : MonoBehaviour
{
    public static ItemTooltip Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI statsText;
    
    void Awake()
    {
        Instance = this;
    }

    public void FillTooltip(ItemData item)
    {
        nameText.text = item.Name;
        statsText.text = $"Rarity: {item.Rarity}\n" +
                        $"Unit type: {item.UnitType}\n\n" +
                        $"EFFECTS\n" +
                        EffectsToText(item);
    }

    public void ClearTooltip()
    {
        nameText.text = "";
        statsText.text = "";
    }

    private string EffectsToText(ItemData item)
    {
        string effectsText = "";
        foreach (var effect in item.ListEffects)
        {
            effectsText += $" {effect.value}% {effect.effect}\n";
        }
        return effectsText;
    }
}