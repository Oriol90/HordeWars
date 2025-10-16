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

    private static readonly List<string> maleInstructorIconPath = new List<string>
    {
        $"Instructor Icons/1",
        $"Instructor Icons/3",
        $"Instructor Icons/7",
        $"Instructor Icons/8",
        $"Instructor Icons/10"
    };
    
    private static readonly List<string> femaleInstructorIconPath = new List<string>
    {
        $"Instructor Icons/2",
        $"Instructor Icons/4",
        $"Instructor Icons/5",
        $"Instructor Icons/6",
        $"Instructor Icons/9"
    };

    public static Sprite Get(Item item)
    {
        return Resources.Load<Sprite>(itemIconPath[item]);
    }

    public static Sprite Get(UnitType unitType)
    {
        return Resources.Load<Sprite>(unitIconPath[unitType]);
    }

    public static string GetRandomInstructorPath(Gender gender)
    {
        string spritePath = "";

        if (gender == Gender.Male)
        {
            int randomIndex = Random.Range(0, maleInstructorIconPath.Count);
            spritePath = maleInstructorIconPath[randomIndex];
        }
        else if (gender == Gender.Female)
        {
            int randomIndex = Random.Range(0, femaleInstructorIconPath.Count);
            spritePath = femaleInstructorIconPath[randomIndex];
        }
        return spritePath;
    }
}
