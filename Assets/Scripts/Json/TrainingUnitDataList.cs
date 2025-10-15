using System.Collections.Generic;

public class TrainingUnitDataList : ObjectManagementDBBase<TrainingUnitData>
{
    public TrainingUnitDataList()
    {
        dataType = DataType.TrainingUnitData;
        objects = GameSaveManager.Load<ICollection<TrainingUnitData>>(dataType);
        if (objects == null) objects = new List<TrainingUnitData>();
    }
    
    public override void Create()
    {
        throw new System.NotImplementedException();
    }

    public override void Get()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}