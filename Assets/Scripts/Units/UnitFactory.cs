using System;
using System.Collections.Generic;
using UnityEngine;

public static class UnitFactory
{
    public static UnitData CreateRandomUnitData()
    {
        UnitType unitType = (UnitType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(UnitType)).Length);
        switch (unitType)
        {
            case UnitType.Archer:
                return new ArcherPO(Utils.CreateRandomNumber(0, 1600), Utils.GetRandomEnumValue<Item>());
            case UnitType.GirlKnight:
                return new GirlKnightPO(Utils.CreateRandomNumber(0, 1600), Utils.GetRandomEnumValue<Item>());
            case UnitType.LeafArcher:
                return new LeafArcherPO(Utils.CreateRandomNumber(0, 1600), Utils.GetRandomEnumValue<Item>());
            case UnitType.Felipe:
                return new FelipePO(Utils.CreateRandomNumber(0, 1600), Utils.GetRandomEnumValue<Item>());
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

        public static UnitData CreateUnitDataFromInstructor(InstructorData instructorData)
    {
        switch (instructorData.trainableUnit)
        {
            case UnitType.Archer:
                return new ArcherPO(0, Utils.GetRandomEnumValue<Item>());
            case UnitType.GirlKnight:
                return new GirlKnightPO(0, Utils.GetRandomEnumValue<Item>());
            case UnitType.LeafArcher:
                return new LeafArcherPO(0, Utils.GetRandomEnumValue<Item>());
            case UnitType.Felipe:
                return new FelipePO(0, Utils.GetRandomEnumValue<Item>());
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public static GameObject SetUnitGO(GameObject unitGO, UnitData unitData, Dictionary<UnitType, BaseStats> dictBaseStats)
    {
        Unit unit = unitGO.GetComponent<Unit>();
        unit.Race = unitData.race;
        unit.UnitType = unitData.unitType;
        unit.Experience = unitData.experience;
        unit.Level = Utils.ExperienceToLevel(unitData.experience);
        unit.BaseStats = dictBaseStats[unitData.unitType];
        //unit.Stats = new UnitStats(unit.BaseStats, unit.Level);
        return unitGO;
    }

    public static Dictionary<UnitType, int> CountUnitsArmy()
    {
        Dictionary<UnitType, int> numUnitsArmy = new Dictionary<UnitType, int>
         {
            {UnitType.Archer, 0},
            {UnitType.LeafArcher, 0},
            {UnitType.GirlKnight, 0},
            {UnitType.Felipe, 0}
         };

        foreach (var unitData in GC.GET_ARMY_LIST)
        {
            switch (unitData)
            {
                case ArcherPO:
                    numUnitsArmy[UnitType.Archer]++;
                    break;
                case LeafArcherPO:
                    numUnitsArmy[UnitType.LeafArcher]++;
                    break;
                case GirlKnightPO:
                    numUnitsArmy[UnitType.GirlKnight]++;
                    break;
                case FelipePO:
                    numUnitsArmy[UnitType.Felipe]++;
                    break;
            }
        }
        return numUnitsArmy;
    }
}