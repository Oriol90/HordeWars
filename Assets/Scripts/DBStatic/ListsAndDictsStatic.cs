using System.Collections.Generic;

public static class ListsAndDictsStatic
{
    //public static TrainingUnitDataList trainingUnitDataListInstance = new TrainingUnitDataList();
    public static List<IObjectManagementDB> objectManagementDBList = new List<IObjectManagementDB>()
    {
        new TrainingUnitDataList()
    };

    public static IObjectManagementDB GetList(DataType dataType)
    {
        return objectManagementDBList.Find(x => x.dataType == dataType);
    }
}