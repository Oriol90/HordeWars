using System.Collections.Generic;

public class InstructorDataList : ObjectManagementDBBase<InstructorData>
{
    public InstructorDataList()
    {
        dataType = DataType.InstructorData;
        objects = GameSaveManager.Load<ICollection<InstructorData>>(dataType);
        if (objects == null) objects = new List<InstructorData>(); 
    }
}