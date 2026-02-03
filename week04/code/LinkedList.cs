using System.Collections;
public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // 1. Creamos el nuevo nodo con el valor recibido
        Node newNode = new(value);

        // 2. Si la lista está vacía (usamos el mismo truco que en InsertHead)
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // 3. Si no está vacía, trabajamos con el final (_tail)
        else
        {
            // El nuevo nodo debe apuntar hacia atrás al viejo tail
            newNode.Prev = _tail;
            
            // El viejo tail ahora debe apuntar hacia adelante al nuevo nodo
            _tail!.Next = newNode;
            
            // Ahora el nuevo nodo es oficialmente el último de la fila
            _tail = newNode;
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // 1. Caso: Lista vacía o con un solo elemento
    // Si head y tail son iguales, la lista quedará vacía (null)
    if (_head == _tail)
    {
        _head = null;
        _tail = null;
    }
    // 2. Caso: Hay más de un elemento
    else if (_tail is not null)
    {
        // El penúltimo (_tail.Prev) debe dejar de apuntar al actual último.
        // El "Next" del penúltimo ahora será null.
        _tail.Prev!.Next = null;

        // Ahora movemos la etiqueta de "_tail" hacia atrás
        _tail = _tail.Prev;
    }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        Node? curr = _head; // Empezamos a buscar desde el inicio
    
    while (curr is not null)
    {
        if (curr.Data == value)
        {
            // ¡Lo encontramos! Ahora decidimos cómo quitarlo:
            
            if (curr == _head)
            {
                RemoveHead();
            }
            else if (curr == _tail)
            {
                RemoveTail();
            }
            else
            {
                // Está en medio. Conectamos al anterior con el siguiente.
                curr.Prev!.Next = curr.Next; // El de atrás ahora apunta al de adelante
                curr.Next!.Prev = curr.Prev; // El de adelante ahora apunta al de atrás
            }
            return; // Importante: Salimos del método en cuanto borramos el primero
        }
        curr = curr.Next; // Seguimos buscando en el siguiente
    }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head; // Empezamos desde el inicio

        while (curr is not null)
        {
            // Si el valor del nodo actual es el que buscamos
            if (curr.Data == oldValue)
            {
                curr.Data = newValue; // ¡Cambiamos el valor!
            }
            
            // Seguimos al siguiente nodo pase lo que pase
            curr = curr.Next; 
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // Empezamos por el final
        var curr = _tail; 

        while (curr is not null)
        {
            // Entregamos el valor actual al foreach
            yield return curr.Data; 

            // ¡Damos un paso hacia ATRÁS!
            curr = curr.Prev; 
        }    
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}