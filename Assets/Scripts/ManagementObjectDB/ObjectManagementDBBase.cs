using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;

public abstract class ObjectManagementDBBase<T> : IObjectManagementDB where T : IElementDB
{
    public DataType dataType { get; set; }
    public ICollection<T> objects { get; set; }

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
    
    public void Update(object obj)
    {
        var toUpdate = objects.Where(o => o.id == ((T)obj).id).First();
        if (toUpdate != null)
        {
            objects.Remove(toUpdate);
            objects.Add((T)obj);
            Save();
        }
    }

    public void ReplaceList(List<object> objList)
    {
        objects.Clear();
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

    public void DeleteAll()
    {
        objects.Clear();
        Save();
    }
}