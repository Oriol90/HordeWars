using System.Collections.Generic;

public static class EventExecutor
{
    
    public static void FinishTraining(TrainingUnitData trainingUnitData)
    {
        List<object> courtyardUnits = new List<object>();
        for (int i = 0; i < trainingUnitData.numUnitsToTrain; i++)
        {
            courtyardUnits.Add(UnitFactory.CreateUnitDataFromInstructor(trainingUnitData.instructorData));
        }
        Collections.GetList(DataType.CourtyardUnitsData).AddList(courtyardUnits);
        Collections.GetList(DataType.TrainingUnitData).Delete(trainingUnitData.id);
    }
}