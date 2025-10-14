using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;

public abstract class ObjectManagementDBBase<T> : IObjectManagementDB<T>
{
    public DataType dataType { get; set; }
    public ICollection<T> objects { get; set; }

    public abstract void Update();
    public abstract void Get();
    public abstract void Create();

    public void Save()
    {

    }

    public void Delete(Func<T, bool> predicate)
    {
        objects.Where(predicate);
        ICollection<T> deletedObjects = objects.Where(predicate).ToList();
        foreach(var obj in deletedObjects)
        {
            objects.Remove(obj);
        }
        GameSaveManager.Save(objects, dataType); 
    }
    
}