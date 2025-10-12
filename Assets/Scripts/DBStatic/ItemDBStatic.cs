using System.Collections.Generic;

public static class ItemDBStatic
{
    private static readonly Dictionary <Item, ItemData> Items = new Dictionary<Item, ItemData>
        {
            { Item.WoodenSword, new ItemData {
                Name = "Wooden Sword",
                UnitType = UnitType.GirlKnight,
                Item = Item.WoodenSword,
                Rarity = Rarity.Common,
                Description = "A basic wooden sword.",
                ListEffects = new List<EffectModifier> {
                    new EffectModifier { effect = Effect.AttackBoost, value = 5 },
                    new EffectModifier { effect = Effect.DefenseBoost, value = 2 }
                }
            }},
            { Item.IronShield, new ItemData {
                Name = "Iron Shield",
                UnitType = UnitType.GirlKnight,
                Item = Item.IronShield,
                Rarity = Rarity.Uncommon,
                Description = "A sturdy iron shield.",
                ListEffects = new List<EffectModifier> {
                    new EffectModifier { effect = Effect.DefenseBoost, value = 10 },
                    new EffectModifier { effect = Effect.HealthBoost, value = 20 }
                }
            }},
            { Item.Bow, new ItemData {
                Name = "Bow",
                UnitType = UnitType.LeafArcher,
                Item = Item.Bow,
                Rarity = Rarity.Mythic,
                Description = "A bow for ranged attacks.",
                ListEffects = new List<EffectModifier> {
                    new EffectModifier { effect = Effect.AttackBoost, value = 7 },
                    new EffectModifier { effect = Effect.Freeze, value = 5 }
                }
            }},
            { Item.Staff, new ItemData {
                Name = "Staff",
                UnitType = UnitType.Felipe,
                Item = Item.Staff,
                Rarity = Rarity.Epic,
                Description = "A magical staff.",
                ListEffects = new List<EffectModifier> {
                    new EffectModifier { effect = Effect.ManaBoost, value = 25 },
                    new EffectModifier { effect = Effect.SpellPowerBoost, value = 10 }
                }
            }},
            { Item.Ring, new ItemData {
                Name = "Ring",
                UnitType = UnitType.Felipe,
                Item = Item.Ring,
                Rarity = Rarity.Celestial,
                Description = "A ring with mystical properties.",
                ListEffects = new List<EffectModifier> {
                    new EffectModifier { effect = Effect.HealthBoost, value = 50 },
                    new EffectModifier { effect = Effect.AttackBoost, value = 15 }
                }
            }},
            { Item.MagicWand, new ItemData {
                Name = "Magic Wand",
                UnitType = UnitType.Felipe,
                Item = Item.MagicWand,
                Rarity = Rarity.Rare,
                Description = "A wand imbued with magical powers.",
                ListEffects = new List<EffectModifier> {
                    new EffectModifier { effect = Effect.ManaBoost, value = 15 },
                    new EffectModifier { effect = Effect.SpellPowerBoost, value = 8 }
                }
            }
        }};

    public static ItemData Get(Item item)
    {
        return Items[item];
    }
}
