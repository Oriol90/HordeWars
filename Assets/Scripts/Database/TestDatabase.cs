using UnityEngine;
using System.Collections.Generic;


public class TestDatabase : MonoBehaviour
{
    private DatabaseManager _dbManager;

    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        _dbManager = FindFirstObjectByType<DatabaseManager>();

        List<UnitData> units = _dbManager.GetAllUnits();

        foreach (UnitData unit in units)
        {
            Debug.Log($"Unidad: {unit.Name}, HP: {unit.Health}, ATK: {unit.Attack}");
        }

        // Simulación: Subir de nivel una unidad y actualizarla en la base de datos
        UnitData girlKnight = units.Find(u => u.Name == "GirlKnight");
        if (girlKnight != null)
        {
            girlKnight.Level++;
            girlKnight.Health += 20; // Aumenta la vida con el nivel
            _dbManager.UpdateUnit(girlKnight);
            Debug.Log($"Nueva Vida de GirlKnight: {girlKnight.Health}");
        }
    }
}
