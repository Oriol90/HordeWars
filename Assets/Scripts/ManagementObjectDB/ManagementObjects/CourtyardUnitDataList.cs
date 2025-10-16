using System.Collections.Generic;

public class CourtyardUnitDataList : ObjectManagementDBBase<UnitData>
{
    public CourtyardUnitDataList()
    {
        dataType = DataType.CourtyardUnitsData;
        objects = GameSaveManager.Load<ICollection<UnitData>>(dataType);
        if (objects == null) objects = new List<UnitData>();
    }
}