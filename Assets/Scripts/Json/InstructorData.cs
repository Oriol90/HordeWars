using System.Collections.Generic;

public class InstructorData
{
    public string instructorName;
    public UnitType trainableUnit;
    public Rarity rarity;
    public StatsInstructor stats;
    public List<Mastery> mastery;
    public int trainingCost;
    public int trainingTime;
    public int startTime;
    public bool isTraining;
    public bool unlocked;

    public InstructorData(string instructorName, UnitType trainableUnit, Rarity rarity, StatsInstructor stats, List<Mastery> mastery, int trainingCost, int trainingTime)
    {
        this.instructorName = instructorName;
        this.trainableUnit = trainableUnit;
        this.rarity = rarity;
        this.stats = stats;
        this.mastery = mastery;
        this.trainingCost = trainingCost;
        this.trainingTime = trainingTime;
    }
}