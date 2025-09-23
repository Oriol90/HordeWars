using System.Collections.Generic;

public static class StaticDataCamp
{
    public static List<InstructorData> GetInstructorList(){
        return GameSaveManager.Load<List<InstructorData>>(DataType.InstructorData);
    }
}