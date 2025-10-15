using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;

public abstract class ObjectManagementDBBase<T> : IObjectManagementDB where T : IElementDB
{
    public DataType dataType { get; set; }
    public ICollection<T> objects { get; set; }

    public abstract void Update();
    public abstract void Get();
    public abstract void Create();

    public void Save()
    {

    }

    public void Delete(Guid id)
    {

        var deletedObjects = objects.Where(obj => obj.id == id).ToList();
        foreach (var obj in deletedObjects)
        {
            objects.Remove(obj);
        }
        GameSaveManager.Save(objects, dataType);
    }
    
}