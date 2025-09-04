using System;
using UnityEngine;

[Serializable]
public class LeafArcher : Unit
{

    public LeafArcher(float experience, BaseStats baseStats, GameObject prefab)
    {
        Race = Race.Human;
        UnitType = UnitType.LeafArcher;

        Experience = experience;
        Level = (int)Math.Floor(experience);

        BaseStats = baseStats;
        Stats = new UnitStats(baseStats, Level);

        this.prefab = prefab;
    }

    protected override void Start()
    {
        base.Start(); // Llama al Start() de Unit
    }

    protected override void Update()
    {
        base.Update(); // Llama al Update() de Unit
    }

    private void CalcStats()
    {
        
    }
}