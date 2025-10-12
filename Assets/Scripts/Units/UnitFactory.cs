using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory
{
    public List<UnitPO> LoadArmy()
    {
        List<UnitData> listUnitData = GameSaveManager.Load<List<UnitData>>(DataType.ArmyData);
        Dictionary<UnitType, BaseStats> dictBaseStats = GameSaveManager.Load<Dictionary<UnitType, BaseStats>>(DataType.BaseStats);
        return UnitDataToUnit(listUnitData, dictBaseStats);
    }

    public List<UnitPO> CourtYardUnits()
    {
        List<UnitData> listUnitData = GameSaveManager.Load<List<UnitData>>(DataType.CourtyardUnitsData);
        Dictionary<UnitType, BaseStats> dictBaseStats = GameSaveManager.Load<Dictionary<UnitType, BaseStats>>(DataType.BaseStats);
        return UnitDataToUnit(listUnitData, dictBaseStats);
    }

    public List<UnitPO> UnitDataToUnit(List<UnitData> listUnitData, Dictionary<UnitType, BaseStats> dictBaseStats)
    {
        List<UnitPO> listUnits = new List<UnitPO>();
        foreach (var unitData in listUnitData)
        {
            UnitPO unit = null;
            switch (unitData.unitType)
            {
                case UnitType.Archer:
                    unit = new ArcherPO(unitData.experience, dictBaseStats[UnitType.Archer], ExperienceToLevel(unitData.experience), unitData.item);
                    break;
                case UnitType.GirlKnight:
                    unit = new GirlKnightPO(unitData.experience, dictBaseStats[UnitType.GirlKnight], ExperienceToLevel(unitData.experience), unitData.item);
                    break;
                case UnitType.LeafArcher:
                    unit = new LeafArcherPO(unitData.experience, dictBaseStats[UnitType.LeafArcher], ExperienceToLevel(unitData.experience), unitData.item);
                    break;
                case UnitType.Felipe:
                    unit = new FelipePO(unitData.experience, dictBaseStats[UnitType.Felipe], ExperienceToLevel(unitData.experience), unitData.item);
                    break;
            }
            listUnits.Add(unit);
        }
        return listUnits;
    }

    private int ExperienceToLevel(int exp)
    {
        switch (exp)
        {
            case int n when n < 100: return 1;
            case int n when n < 300: return 2;
            case int n when n < 600: return 3;
            case int n when n < 1000: return 4;
            case int n when n < 1500: return 5;
            case int n when n >= 1500: return 6;
            default: return 0;
        }
    }

    public List<UnitData> UnitToUnitData(List<UnitPO> listUnitPO)
    {
        List<UnitData> listUnitData = new List<UnitData>();
        foreach (var unitPO in listUnitPO)
        {
            UnitData unitData = new UnitData(unitPO.Race, unitPO.Experience, unitPO.UnitType);
            listUnitData.Add(unitData);
        }
        return listUnitData;
    }

    public GameObject SetUnitGO(GameObject unitGO, UnitData unitData, Dictionary<UnitType, BaseStats> dictBaseStats)
    {
        Unit unit = unitGO.GetComponent<Unit>();
        unit.Race = unitData.race;
        unit.UnitType = unitData.unitType;
        unit.Experience = unitData.experience;
        unit.Level = ExperienceToLevel(unitData.experience);
        unit.BaseStats = dictBaseStats[unitData.unitType];
        unit.Stats = new UnitStats(unit.BaseStats, unit.Level);
        return unitGO;
    }

    public UnitPO CreateNewUnitPO(UnitType unitType)
    {
        Dictionary<UnitType, BaseStats> dictBaseStats = GameSaveManager.Load<Dictionary<UnitType, BaseStats>>(DataType.BaseStats);

        switch (unitType)
        {
            case UnitType.Archer:
                return new ArcherPO(0, dictBaseStats[UnitType.Archer], 0, Item.Bow);
            case UnitType.GirlKnight:
                return new GirlKnightPO(0, dictBaseStats[UnitType.GirlKnight], 0, Item.IronShield);
            case UnitType.LeafArcher:
                return new LeafArcherPO(0, dictBaseStats[UnitType.LeafArcher], 0, Item.Bow);
            default:
                return null;
        }
    }

    public Dictionary<UnitType, int> CountUnitsArmy(List<UnitPO> army)
    {
        Dictionary<UnitType, int> numUnitsArmy = new Dictionary<UnitType, int>
         {
            {UnitType.Archer, 0},
            {UnitType.LeafArcher, 0},
            {UnitType.GirlKnight, 0},
         };


        foreach (var unitData in army)
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
            }
        }
        return numUnitsArmy;
    }
}