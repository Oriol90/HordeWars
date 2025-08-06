using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class MoveUnitManager
{
    public static void MoveUnit(Vector3Int unitPos, Vector3Int goalPos, Tilemap tilemap, LineRenderer lineRenderer)
    {
        List<Vector3Int> path = PathFinder.FindPath(unitPos, goalPos, tilemap);
        DrawPath(path, lineRenderer, tilemap);
    }

    private static void DrawPath(List<Vector3Int> path, LineRenderer lineRenderer, Tilemap tilemap)
    {
        lineRenderer.positionCount = path.Count;
        for (int i = 0; i < path.Count; i++)
        {
            lineRenderer.SetPosition(i, tilemap.CellToWorld(path[i]) + tilemap.tileAnchor);
        }
    }

    /*private static List<Vector3Int> FindBestPath(Vector3Int unitPos, Vector3Int goalPos)
    {

        List<Vector3Int> path = new();
        int heuristic = GetHeuristic(unitPos, goalPos);
        Vector3Int bestPath = new();
        var abiertos = new PriorityQueue<Vector3Int>();

        while (heuristic)



            return GetNeighbors(unitPos);

        return new List<Vector3Int>
        {
            new Vector3Int(1, -7, 0),
            new Vector3Int(1, -6, 0),
            new Vector3Int(1, -5, 0),
            new Vector3Int(1, -4, 0),
            new Vector3Int(1, -3, 0),
            new Vector3Int(1, -2, 0),
            new Vector3Int(1, -1, 0),
            new Vector3Int(1, 0, 0),
            new Vector3Int(1, 1, 0)
        };
    }*/





    /*private List<Vector3Int> FindHexPath(Vector3Int start, Vector3Int goal, Tilemap tilemap)
    {
        var openSet = new SimplePriorityQueue<HexTile, float>();
        var allNodes = new Dictionary<Vector3Int, HexTile>();

        HexTile startTile = new HexTile(start);
        openSet.Enqueue(startTile, 0);
        allNodes[start] = startTile;

        while (openSet.Count > 0)
        {
            HexTile current = openSet.Dequeue();

            if (current.position == goal)
            {
                // Reconstruye el camino
                List<Vector3Int> path = new();
                while (current != null)
                {
                    path.Add(current.position);
                    current = current.cameFrom;
                }
                path.Reverse();
                return path;
            }

            foreach (var neighborPos in GetHexNeighbors(current.position))
            {
                if (!tilemap.HasTile(neighborPos)) continue; // Ignora celdas vacías

                float tentativeCost = allNodes[current.position].cost + 1;

                if (!allNodes.ContainsKey(neighborPos) || tentativeCost < allNodes[neighborPos].cost)
                {
                    HexTile neighbor = new HexTile(neighborPos);
                    neighbor.cost = tentativeCost;
                    neighbor.cameFrom = current;
                    allNodes[neighborPos] = neighbor;

                    float priority = tentativeCost + Heuristic(neighborPos, goal);
                    openSet.Enqueue(neighbor, priority);
                }
            }
        }

        return null; // No path found
    }*/

    private static void DrawPath(List<Vector3Int> path, Tilemap tilemap, LineRenderer line)
    {
        line.positionCount = path.Count;
        for (int i = 0; i < path.Count; i++)
        {
            line.SetPosition(i, tilemap.GetCellCenterWorld(path[i]));
        }
    }
}