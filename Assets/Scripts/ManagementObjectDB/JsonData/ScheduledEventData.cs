using System;

[Serializable]
public class ScheduledEventData : IElementDB
{
    public Guid id { get; set; } = Guid.NewGuid();
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