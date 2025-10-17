using System.Collections.Generic;

public class TokenDataList : ObjectManagementDBBase<TokenData>
{
    public TokenDataList()
    {
        dataType = DataType.TokenData;
        objects = GameSaveManager.Load<ICollection<TokenData>>(dataType);
        if (objects == null) objects = new List<TokenData>();
    }
}