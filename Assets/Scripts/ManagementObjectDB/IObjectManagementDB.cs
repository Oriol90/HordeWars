using System;
using System.Collections.Generic;

public interface IObjectManagementDB<T>
{
    DataType dataType { get; set; }
    ICollection<T> objects { get; set; }

    void Update();
    void Get();
    void Save();
    void Create();
    void Delete(Func<T, bool> predicate);
}