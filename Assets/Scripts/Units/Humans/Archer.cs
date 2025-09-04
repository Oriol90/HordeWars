using System;
using UnityEngine;

[Serializable]
public class Archer : Unit
{

    public Archer(float experience, BaseStats baseStats, GameObject prefab)
    {
        Race = Race.Human;
        UnitType = UnitType.Archer;

        Experience = experience;
        Level = (int)Math.Floor(experience);

        BaseStats = baseStats;
        Stats = new UnitStats(baseStats, Level);

        this.prefab = prefab;
        
        CalcStats();
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