using System.Collections.Generic;

public class ArmyDataList : ObjectManagementDBBase<UnitData>
{
    public ArmyDataList()
    {
        dataType = DataType.ArmyData;
        objects = GameSaveManager.Load<ICollection<UnitData>>(dataType);
        if (objects == null) objects = new List<UnitData>();
    }
}