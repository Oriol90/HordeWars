using System;
using System.Collections.Generic;

[Serializable]
public class InstructorData : IElementDB
{
    public Guid id { get; set; } = Guid.NewGuid();
    public string instructorName;
    public Gender gender;
    public UnitType trainableUnit;
    public Rarity rarity;
    public string spritePath;
    public List<Mastery> masteryList;
    public int trainingCost;
    public int trainingTime;
    public int startTime;
    public bool isTraining;
    public bool unlocked;


    public InstructorData(string instructorName, Gender gender, UnitType trainableUnit, Rarity rarity, List<Mastery> masteryList, int trainingCost, int trainingTime, string spritePath)
    {
        this.instructorName = instructorName;
        this.spritePath = spritePath;
        this.gender = gender;
        this.trainableUnit = trainableUnit;
        this.rarity = rarity;
        this.masteryList = masteryList;
        this.trainingCost = trainingCost;
        this.trainingTime = trainingTime;
    }

    public string GetInfo()
    {
        string info =
            $"Rarity: {rarity}\n" +
            $"Training Cost: {trainingCost} gold\n" +
            $"Training Time: {Utils.BeautifyTime(trainingTime)}\n" +
            $"Trainable Unit: {trainableUnit}\n" +
            $"Masteries:\n{MasteriesToText()}\n";
        return info;
    }

    private string MasteriesToText()
    {
        string effectsText = "";
        foreach (var mastery in masteryList)
        {
            effectsText += $" - {mastery}\n";
        }
        return effectsText;
    }
}