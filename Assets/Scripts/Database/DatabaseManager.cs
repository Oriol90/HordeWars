using System.Collections.Generic;
using LiteDB;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private string _dbPath;  // Ya no es estática, se inicializa en Awake()
    private LiteDatabase _database;
    private ILiteCollection<UnitData> _unitsCollection;

    void Awake()
    {
        _dbPath = Application.persistentDataPath + "/hordewars.db";  // Ahora se inicializa correctamente
        _database = new LiteDatabase(_dbPath);
        _unitsCollection = _database.GetCollection<UnitData>("units");

        if (_unitsCollection.Count() == 0)
        {
            InitializeDatabase();
        }
    }

    private void InitializeDatabase()
    {
        List<UnitData> initialUnits = new List<UnitData>
        {
            new UnitData { Name = "GirlKnight", Health = 100, Attack = 20, Defense = 10, Speed = 5, Experience = 0, Level = 1 },
            new UnitData { Name = "Archer", Health = 80, Attack = 25, Defense = 5, Speed = 7, Experience = 0, Level = 1 }
        };

        _unitsCollection.InsertBulk(initialUnits);
        Debug.Log("Base de datos inicializada.");
    }

    public List<UnitData> GetAllUnits()
    {
        return new List<UnitData>(_unitsCollection.FindAll());  // Convierte IEnumerable a List
    }

    public void UpdateUnit(UnitData unit)
    {
        _unitsCollection.Update(unit);
    }

    private void OnDestroy()
    {
        _database.Dispose(); // Cierra la base de datos cuando el objeto se destruye
    }
}
