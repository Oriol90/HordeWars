using System;
using System.Collections.Generic;

public interface IObjectManagementDB
{
    DataType dataType { get; set; }

    void Update();
    void Get();
    void Save();
    void Create();
    void Delete(Guid id);
}