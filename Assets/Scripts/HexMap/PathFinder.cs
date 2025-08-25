using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathFinder
{
    // Método principal que calcula la ruta más corta desde 'unitPos' a 'fin'
    // usando una función para saber si una posición es transitable y otra para obtener su coste
    public static List<Vector3Int> FindPath(Vector3Int unitPos, Vector3Int goalPos, Tilemap tilemap)        // función que da el coste de moverse a esa celda
    {
        // Cola de prioridad con los nodos open (por visitar), ordenados por coste + heurística
        var open = new PriorityQueue<Vector3Int>();

        // Diccionario para reconstruir la ruta: para cada nodo, guarda de dónde vino
        var from = new Dictionary<Vector3Int, Vector3Int>();

        // Diccionario que guarda el coste acumulado más bajo desde unitPos hasta cada nodo
        var costTo = new Dictionary<Vector3Int, int>();

        // Añadimos el punto inicial a la cola con prioridad 0
        open.Enqueue(unitPos, 0);
        costTo[unitPos] = 0;

        // Mientras haya nodos por visitar
        while (open.Count > 0)
        {
            // Sacamos el nodo con menor coste + heurística
            Vector3Int actual = open.Dequeue();

            // Si hemos llegado al destino, reconstruimos y devolvemos la ruta
            if (actual == goalPos)
                return ReconstruirRuta(from, actual);

            foreach (var neightbor in GetNeighbors(actual))
            {
                if (!transitable(neightbor, tilemap)) continue;

                // Calculamos el nuevo coste acumulado si vamos hasta ese vecino
                int nuevoCoste = costTo[actual] + getCost(neightbor, tilemap);

                // Si aún no tenemos un coste para este vecino o hemos encontrado uno mejor (más barato)
                if (!costTo.ContainsKey(neightbor) || nuevoCoste < costTo[neightbor])
                {
                    costTo[neightbor] = nuevoCoste;

                    // Calculamos la prioridad (coste + heurística hacia el objetivo)
                    int prioridad = nuevoCoste + GetHeuristic(neightbor, goalPos);

                    // Añadimos el vecino a la cola con su prioridad
                    open.Enqueue(neightbor, prioridad);
                    from[neightbor] = actual;
                }
            }
        }

        // Si salimos del bucle, no hay ruta posible
        return null;
    }

    // Reconstruye el camino desde el nodo final hacia el unitPos usando el diccionario from
    private static List<Vector3Int> ReconstruirRuta(Dictionary<Vector3Int, Vector3Int> from, Vector3Int actual)
    {
        var ruta = new List<Vector3Int> { actual };

        // Retrocedemos desde el final al unitPos
        while (from.ContainsKey(actual))
        {
            actual = from[actual];
            ruta.Insert(0, actual); // insertamos al unitPos de la lista
        }

        return ruta;
    }

    private static readonly List<Vector3Int> HexNeighborsPair = new List<Vector3Int>
    {
        new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 1, 0),
        new Vector3Int(-1, 0, 0), new Vector3Int(-1, -1, 0), new Vector3Int(0, -1, 0)
    };

    private static readonly List<Vector3Int> HexNeighborsOdd = new List<Vector3Int>
    {
        new Vector3Int(1, 0, 0), new Vector3Int(1, 1, 0), new Vector3Int(0, 1, 0),
        new Vector3Int(-1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, -1, 0)
    };

    private static List<Vector3Int> GetNeighbors(Vector3Int pos)
    {
        List<Vector3Int> neighbors = new();
        List<Vector3Int> HexNeighbors = pos.y % 2 == 0 ? HexNeighborsPair : HexNeighborsOdd;

        foreach (var offset in HexNeighbors)
        {
            neighbors.Add(pos + offset);
        }
        return neighbors;
    }

    private static int GetHeuristic(Vector3Int a, Vector3Int b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y); // Distancia Manhattan para hexágonos
    }

    private static bool transitable(Vector3Int cellPos, Tilemap tilemap)
    {
        return tilemap.GetTile(cellPos) !=null;
    }

    private static int getCost(Vector3Int tile, Tilemap tilemap)
    {
        return Utils.GetTileName(tilemap.GetTile(tile).name);
    }
}