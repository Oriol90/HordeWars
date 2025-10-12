using System.Collections.Generic;

public class ItemData
{
    public string Name { get; set; }
    public UnitType UnitType { get; set; }
    public Item Item { get; set; }
    public Rarity Rarity { get; set; }
    public List<EffectModifier> ListEffects { get; set; }
    public string Description { get; set; }

    public string GetInfo()
    {
        return  $"Rarity: {Rarity}\n" +
                $"Effects:\n{EffectsToText()}" +
                $"Description: {Description}";
    } 

    private string EffectsToText()
    {
        string effectsText = "";
        foreach (var effect in ListEffects)
        {
            effectsText += $" {effect.value}% {effect.effect}\n";
        }
        return effectsText;
    } 
}

 