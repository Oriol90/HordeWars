using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;

public abstract class ObjectManagementDBBase<T> : IObjectManagementDB where T : IElementDB
{
    public DataType dataType { get; set; }
    public ICollection<T> objects { get; set; }
    //public Dictionary<T, int> dictObject { get; set; }

    private void Save()
    {
        GameSaveManager.Save(objects, dataType);
    }

    public void Add(object obj)
    {
        objects.Add((T)obj);
        Save();
    }
    
    public void AddList(List<object> objList)
    {
        foreach (var obj in objList)
        {
            objects.Add((T)obj);
        }
        Save();
    }

    public void Delete(Guid id)
    {
        var deletedObjects = objects.Where(obj => obj.id == id).ToList();
        foreach (var obj in deletedObjects)
        {
            objects.Remove(obj);
        }
        Save();
    }
}