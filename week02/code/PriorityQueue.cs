using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        // ERROR 1: Si la cola está vacía, debe lanzar una excepción
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var highPriorityIndex = 0;

        // ERROR 2: El bucle original decía "index < _queue.Count - 1"
        // Eso ignoraba el último elemento. Se corrige quitando el "- 1".
        for (int index = 1; index < _queue.Count; index++)
        {
            // ERROR 3: El código original usaba ">=" 
            // Se cambia a ">" para que si hay empate, se quede con el que llegó primero (FIFO).
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // Guardamos el valor para devolverlo al final
        var value = _queue[highPriorityIndex].Value;

        // ERROR 4: El código original no borraba el elemento. 
        // ¡Debemos quitarlo de la lista!
        _queue.RemoveAt(highPriorityIndex);

        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

// Esta clase ayuda a guardar el valor y la prioridad juntos
internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}