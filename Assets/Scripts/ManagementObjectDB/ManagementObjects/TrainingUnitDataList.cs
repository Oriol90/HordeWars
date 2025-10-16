using System.Collections.Generic;

public class TrainingUnitDataList : ObjectManagementDBBase<TrainingUnitData>
{
    public TrainingUnitDataList()
    {
        dataType = DataType.TrainingUnitData;
        objects = GameSaveManager.Load<ICollection<TrainingUnitData>>(dataType);
        if (objects == null) objects = new List<TrainingUnitData>(); 
    }
}