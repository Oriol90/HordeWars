using System.Collections.Generic;

public static class DefaultUnits
{
    public static List<UnitData> GetDefaultUnits()
    {
        return new List<UnitData>
        {
            new() { Name = "GirlKnight", Health = 100, Attack = 20, Defense = 10, Speed = 5 },
            new() { Name = "Archer", Health = 80, Attack = 25, Defense = 5, Speed = 7 },
            new() { Name = "Spearman", Health = 120, Attack = 15, Defense = 20, Speed = 4 }
        };
    }
}
