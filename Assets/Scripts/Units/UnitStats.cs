public class UnitStats
{
    public int Life { get; set; }
    public int Attack { get; set; }
    public float AttackSpeed { get; set; }
    public int Defense { get; set; }
    public int DarkResist { get; set; }
    public float MoveSpeed { get; set; }
    public int BoneCost { get; set; }
    public int LightCost { get; set; }
    public int Faith { get; set; }

    public UnitStats(BaseStats baseStats, int level)
    {
        Life = baseStats.life[level - 1];
        Attack = baseStats.attack[level - 1];
        AttackSpeed = baseStats.attackSpeed[level - 1];
        Defense = baseStats.defense[level - 1];
        DarkResist = baseStats.darkResist[level - 1];
        MoveSpeed = baseStats.moveSpeed[level - 1];
        BoneCost = baseStats.boneCost;
        LightCost = baseStats.lightCost;
        Faith = baseStats.faith;
    }
}