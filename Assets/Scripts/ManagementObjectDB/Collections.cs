using System.Collections.Generic;

public static class Collections
{
    public static List<IObjectManagementDB> objectManagementDBList = new List<IObjectManagementDB>()    {
        new TrainingUnitDataList(),
        new CourtyardUnitDataList(),
        new InstructorDataList(),
        new ScheduledEventDataList(),
        new ArmyDataList(),
        new ArmoryDataList(),
        new TokenDataList()
    };
    

    public static IObjectManagementDB GetList(DataType dataType)
    {
        return objectManagementDBList.Find(x => x.dataType == dataType);
    }
}