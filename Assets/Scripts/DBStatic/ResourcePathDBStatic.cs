using System.Collections.Generic;
using UnityEngine;

public static class ResourcePathDBStatic
{
    private static readonly Dictionary<Item, string> itemIconPath = new Dictionary<Item, string>
    {
        { Item.WoodenSword, $"Item Icons/fc1448" },
        { Item.IronShield, $"Item Icons/fc1811" },
        { Item.MagicWand, $"Item Icons/fc1489" },
        { Item.Bow, $"Item Icons/fc1515" },
        { Item.Staff, $"Item Icons/fc1710" },
        { Item.Ring, $"Item Icons/fc2185" }
    };
    
    private static readonly Dictionary<UnitType, string> unitIconPath = new Dictionary<UnitType, string>
    {
        { UnitType.Archer, $"Unit Icons/icon099" },
        { UnitType.Felipe, $"Unit Icons/icon105" },
        { UnitType.GirlKnight, $"Unit Icons/icon098" },
        { UnitType.LeafArcher, "Unit Icons/icon094" }
    };

    public static Sprite Get(Item item)
    {
        return Resources.Load<Sprite>(itemIconPath[item]);
    }

    public static Sprite Get(UnitType unitType)
    {
        return Resources.Load<Sprite>(unitIconPath[unitType]);
    }
}
