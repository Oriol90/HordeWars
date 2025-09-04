using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class UnitFactory
{
    public GameObject LeafArcherPrefab;//NO FUNCIONA
    public GameObject ArcherPrefab;    //NO FUNCIONA
    public GameObject GirlKnightPrefab;//NO FUNCIONA

    public List<Unit> LoadArmy()
    {
        List<UnitData> listUnitData = GameSaveManager.Load<List<UnitData>>(DataType.ArmyData);
        Dictionary<UnitType, BaseStats> dictBaseStats = GameSaveManager.Load<Dictionary<UnitType, BaseStats>>(DataType.BaseStats);
        return UnitDataToUnit(listUnitData, dictBaseStats);
    }

    public List<Unit> UnitDataToUnit(List<UnitData> listUnitData, Dictionary<UnitType, BaseStats> dictBaseStats)
    {
        List<Unit> army = new List<Unit>();
        foreach (var unitData in listUnitData)
        {
            Unit unit = null;

            switch (unitData.unitType)
            {
                case UnitType.Archer:
                    unit = new Archer(unitData.experience, dictBaseStats[UnitType.Archer], ArcherPrefab);
                    break;
                case UnitType.GirlKnight:
                    unit = new GirlKnight(unitData.experience, dictBaseStats[UnitType.GirlKnight], GirlKnightPrefab);
                    break;
                case UnitType.LeafArcher:
                    unit = new LeafArcher(unitData.experience, dictBaseStats[UnitType.LeafArcher], LeafArcherPrefab);
                    break;
            }
            army.Add(unit);
        }

        return army;
    }

    public GameObject SetUnitGO(GameObject unitGO, UnitData unitData, Dictionary<UnitType, BaseStats> dictBaseStats)
    {
        Unit unit = unitGO.GetComponent<Unit>();
        unit.Race = unitData.race;
        unit.UnitType = unitData.unitType;
        unit.Experience = unitData.experience;
        unit.Level = (int)Math.Floor(unitData.experience);
        unit.BaseStats = dictBaseStats[unitData.unitType];
        unit.Stats = new UnitStats(unit.BaseStats, unit.Level);
        return unitGO;
    }

    public Dictionary<UnitType, int> CountUnitsArmy(List<Unit> army)
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
                case Archer:
                    numUnitsArmy[UnitType.Archer]++;
                    break;
                case LeafArcher:
                    numUnitsArmy[UnitType.LeafArcher]++;
                    break;
                case GirlKnight:
                    numUnitsArmy[UnitType.GirlKnight]++;
                    break;
            }
        }

        return numUnitsArmy;
    }

    // public static UnitStats CalculateUnitStats(BaseStats baseStats)
    // {
    //     UnitStats unitStats = new UnitStats();

    //     return unitStats;
    // }
}