using System.Collections.Generic;

public static class Collections
{
    public static List<IObjectManagementDB> objectManagementDBList = new List<IObjectManagementDB>()    {
        new TrainingUnitDataList(),
        new CourtyardUnitDataList(),
        new InstructorDataList(),
        new ScheduledEventDataList(),
        new ArmyDataList()
        //new ArmoryDataDict()
    };

    // public static Dictionary<IObjectManagementDB> dataTypeToFileNameDict = new Dictionary<IObjectManagementDB>()
    // {
    //     new ArmoryDataDict()
    // };
    

    public static IObjectManagementDB GetList(DataType dataType)
    {
        return objectManagementDBList.Find(x => x.dataType == dataType);
    }
}