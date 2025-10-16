using System;

[Serializable]
public class TrainingUnitData : IElementDB
{
    public Guid id { get; set; } = Guid.NewGuid();
    public int totalCost;
    public InstructorData instructorData;
    public int numUnitsToTrain;
    public int totalTime;
    public int startedAT;
    public int finishAT;
    public int timeLeft;

    public TrainingUnitData() { }

    public TrainingUnitData(InstructorData instructorData, int numUnitsToTrain, int trainingCost, int trainingTime)
    {
        int currentTime = GameTimeManager.GTM.CurrentTimeInHours;
        this.instructorData = instructorData;
        this.numUnitsToTrain = numUnitsToTrain;

        totalCost = numUnitsToTrain * trainingCost;
        totalTime = numUnitsToTrain * trainingTime;

        startedAT = currentTime;
        finishAT = currentTime + totalTime;
        timeLeft = finishAT - currentTime;
    }

    public void UpdateTimeLeft()
    {
        timeLeft = finishAT - GameTimeManager.GTM.CurrentTimeInHours;
    }

    public string GetInfo()
    {
        return
            $"Unit Type: {instructorData.trainableUnit}          Number of Units: {numUnitsToTrain}\n" +
            $"Total Cost: {totalCost} Gold          Time Left: {Utils.BeautifyTime(timeLeft)}";
    }
}