using UnityEngine;
using UnityEngine.Tilemaps;

public class CellTracker
{
    private bool isUsed;
    private string side;
    private GameObject unit;
    private Tile tile;

    public CellTracker(bool isUsed, string side, GameObject unit, Tile tile)
    {
        this.isUsed = isUsed;
        this.side = side;
        this.unit = unit;
        this.tile = tile;
    }

    public CellTracker(bool isUsed, string side, GameObject unit)
    {
        this.isUsed = isUsed;
        this.side = side;
        this.unit = unit;
    }

    public bool IsUsed{
        get { return isUsed; }
        set { isUsed = value; }
    }

    public string Side{
        get { return side; }
        set { side = value; }
    }

    public GameObject Unit{
        get { return unit; }
        set { unit = value; }
    }

    public Tile Tile{
        get { return tile; }
        set { tile = value; }
    }

}