using System.Collections.Generic;

public class PriorityQueue<T>
{
    private List<(T item, int priority)> elementos = new();

    public int Count => elementos.Count;

    // Añade un elemento con su prioridad
    public void Enqueue(T item, int priority)
    {
        elementos.Add((item, priority));
        // Ordena por prioridad creciente (más bajo primero)
        elementos.Sort((a, b) => a.priority.CompareTo(b.priority));
    }

    // Devuelve y elimina el elemento con menor prioridad
    public T Dequeue()
    {
        var item = elementos[0].item;
        elementos.RemoveAt(0);
        return item;
    }
}