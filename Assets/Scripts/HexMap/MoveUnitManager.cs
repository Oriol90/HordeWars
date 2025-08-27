using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class MoveUnitManager
{
    public static void MoveUnit(Vector3Int unitPos, Vector3Int goalPos, Tilemap tilemap, LineRenderer lineRenderer)
    {
        List<Vector3Int> path = PathFinder.FindPath(HeroController.unitPos, goalPos, tilemap);
        DrawPath(path, lineRenderer, tilemap);
        HeroController.SetPath(path, tilemap);
    }

    private static void DrawPath(List<Vector3Int> path, LineRenderer lineRenderer, Tilemap tilemap)
    {
        lineRenderer.positionCount = path.Count;
        for (int i = 0; i < path.Count; i++)
        {
            lineRenderer.SetPosition(i, tilemap.CellToWorld(path[i]) + tilemap.tileAnchor);
        }
    }
}