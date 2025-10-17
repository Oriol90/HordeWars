using System.Collections.Generic;

public class ArmoryDataList : ObjectManagementDBBase<ArmoryData>
{
    public ArmoryDataList()
    {
        dataType = DataType.ArmoryData;
        objects = GameSaveManager.Load<ICollection<ArmoryData>>(dataType);
        if (objects == null) objects = new List<ArmoryData>(); 
    }
}