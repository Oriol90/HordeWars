using System.Collections.Generic;

public class ScheduledEventDataList : ObjectManagementDBBase<ScheduledEventData>
{
    public ScheduledEventDataList()
    {
        dataType = DataType.ScheduledEventData;
        objects = GameSaveManager.Load<ICollection<ScheduledEventData>>(dataType);
        if (objects == null) objects = new List<ScheduledEventData>(); 
    }
}