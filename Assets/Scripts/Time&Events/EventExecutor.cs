using System;
using System.Collections.Generic;
using System.Linq;

public static class EventExecutor
{
    
    public static void FinishTraining(TrainingUnitData trainingUnitData)
    {
        List<TrainingUnitData> trainingUnitDataList = GameSaveManager.Load<List<TrainingUnitData>>(DataType.TrainingUnitData);
        UnitFactory unitFactory = new UnitFactory();

        List<UnitPO> courtyardUnits = unitFactory.CourtYardUnits();
        for (int i = 0; i < trainingUnitData.numUnitsToTrain; i++)
        {
            courtyardUnits.Add(unitFactory.CreateNewUnitPO(trainingUnitData.instructorData.trainableUnit));
        }

        //TrainingUnitDataList trainingUnitDataListInstance = new TrainingUnitDataList();
        ListsAndDictsStatic.GetList(DataType.TrainingUnitData).Delete(trainingUnitData.id);
        //var A = trainingUnitDataListInstance.objects.Where(t => t.id == trainingUnitData.id).ToList();

        //trainingUnitDataList.RemoveAll(t => t.id == trainingUnitData.id);

        GameSaveManager.Save(courtyardUnits, DataType.CourtyardUnitsData);
        GameSaveManager.Save(trainingUnitDataList, DataType.TrainingUnitData);
    }

}