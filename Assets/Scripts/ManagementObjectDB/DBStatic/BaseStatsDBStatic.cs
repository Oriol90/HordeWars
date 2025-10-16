using System.Collections.Generic;

public class BaseStats
{
    public int[] health { get; set; }
    public int[] attack { get; set; }
    public float[] attackSpeed { get; set; }
    public int[] defense { get; set; }
    public int[] darkResist { get; set; }
    public float[] moveSpeed { get; set; }
    public int boneCost { get; set; }
    public int lightCost { get; set; }
    public int faith { get; set; }

    public BaseStats() { }
}

public static class BaseStatsDBStatic
{
    private static Dictionary<UnitType, BaseStats> dictBaseStats = new Dictionary<UnitType, BaseStats>
    {
        {
            UnitType.LeafArcher,
            new BaseStats {
                health = new int[6] {300, 400, 500, 600, 700, 800},
                attack = new int[6] {150, 160, 170, 180, 200, 220 },
                attackSpeed = new float[6] {0.60f, 0.60f, 0.70f, 0.70f, 0.80f, 0.80f},
                defense = new int[6] {10, 10, 12, 15, 20, 25},
                darkResist = new int[6] {15, 15, 15, 15, 15, 15},
                moveSpeed = new float[6] {2f, 2f, 2f, 2f, 2f, 2f},
                boneCost = 25,
                lightCost = 0,
                faith = 5
            }
        },
        {
            UnitType.Archer,
            new BaseStats {
                health = new int[6] {300, 400, 500, 600, 700, 800},
                attack = new int[6] {150, 160, 170, 180, 200, 220},
                attackSpeed = new float[6] {0.60f, 0.60f, 0.70f, 0.70f, 0.80f, 0.80f},
                defense = new int[6] {10, 10, 12, 15, 20, 25},
                darkResist = new int[6] {15, 15, 15, 15, 15, 15},
                moveSpeed = new float[6] {2f, 2f, 2f, 2f, 2f, 2f},
                boneCost = 25,
                lightCost = 0,
                faith = 5
            }
        },
        {
            UnitType.GirlKnight,
            new BaseStats {
                health = new int[6] {700, 750, 800, 850, 900, 950},
                attack = new int[6] {130, 130, 135, 140, 150, 160},
                attackSpeed = new float[6] {0.50f, 0.50f, 0.50f, 0.50f, 0.50f, 0.50f},
                defense = new int[6] {60, 60, 60, 60, 70, 80},
                darkResist = new int[6] {25, 25, 25, 25, 25, 25},
                moveSpeed = new float[6] {1.8f, 1.8f, 1.8f, 1.85f, 1.9f, 1.95f},
                boneCost = 70,
                lightCost = 0,
                faith = 15
            }
        },
        {
            UnitType.Felipe,
            new BaseStats {
                health = new int[6] {1000, 1100, 1200, 1300, 1400, 1500},
                attack = new int[6] {200, 220, 240, 260, 280, 300},
                attackSpeed = new float[6] {1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f},
                defense = new int[6] {80, 85, 90, 95, 100, 110},
                darkResist = new int[6] {30, 30, 30, 30, 30, 30},
                moveSpeed = new float[6] {1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f},
                boneCost = 150,
                lightCost = 0,
                faith = 50
            }
        }
    };

    public static BaseStats GetBaseStatsByUnitType(UnitType unitType)
    {
        return dictBaseStats[unitType];
    }
}