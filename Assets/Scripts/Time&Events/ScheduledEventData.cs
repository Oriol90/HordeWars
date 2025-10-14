using UnityEngine;

[System.Serializable]
public class ScheduledEventData
{
    public EventType EventType { get; set; }
    public int ExecuteAtHour { get; set; }
    public TrainingUnitData TrainingUnitData { get; set; }

    public ScheduledEventData(){}

    public void SetFinishTraining(int executeAtHour, TrainingUnitData trainingUnitData)
    {
        EventType = EventType.FinishTraining;
        ExecuteAtHour = executeAtHour;
        TrainingUnitData = trainingUnitData;
    }
}