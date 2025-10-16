using System.Collections.Generic;

public class ArmoryDataDict : ObjectManagementDBBase<ArmoryData>
{
    public ArmoryDataDict()
    {
        dataType = DataType.ArmoryData;
        objects = GameSaveManager.Load<ICollection<ArmoryData>>(dataType);
        if (objects == null) objects = new List<ArmoryData>(); 
    }
}