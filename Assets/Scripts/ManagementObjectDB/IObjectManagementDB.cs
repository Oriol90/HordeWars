using System;
using System.Collections.Generic;

public interface IObjectManagementDB
{
    DataType dataType { get; set; }

    void Add(object obj);
    void AddList(List<object> objList);
    void Update(object obj);
    void ReplaceList(List<object> objList);
    void Delete(Guid id);
    void DeleteAll();
}