using System.Collections.Generic;
using UnityEngine;

public class InitSpawner : Spawner
{
    void Start()
    {

        Dictionary<UnitType, BaseStats> dictBaseStats = GameSaveManager.Load<Dictionary<UnitType, BaseStats>>(DataType.BaseStats);

        foreach (var unit in GC.GET_ARMY_LIST)
        {
            Spawn(unit, dictBaseStats);
        }
    }
}
