public class SimpleQueue {
    public static void Run() {
        // Test Cases

        // Test 1
        // Scenario: Enqueue one value and then Dequeue it.
        // Expected Result: It should display 100
        Console.WriteLine("Test 1");
        var queue = new SimpleQueue();
        queue.Enqueue(100);
        var value = queue.Dequeue();
        Console.WriteLine(value);
        // Defect(s) Found:

        Console.WriteLine("------------");

        // Test 2
        // Scenario: Enqueue multiple values and then Dequeue all of them
        // Expected Result: It should display 200, then 300, then 400 in that order
        Console.WriteLine("Test 2");
        queue = new SimpleQueue();
        queue.Enqueue(200);
        queue.Enqueue(300);
        queue.Enqueue(400);
        value = queue.Dequeue();
        Console.WriteLine(value);
        value = queue.Dequeue();
        Console.WriteLine(value);
        value = queue.Dequeue();
        Console.WriteLine(value);
        // Defect(s) Found: 

        Console.WriteLine("------------");

        // Test 3
        // Scenario: Dequeue from an empty Queue
        // Expected Result: An exception should be raised
        Console.WriteLine("Test 3");
        queue = new SimpleQueue();
        try {
            queue.Dequeue();
            Console.WriteLine("Oops ... This shouldn't have worked.");
        }
        catch (IndexOutOfRangeException) {
            Console.WriteLine("I got the exception as expected.");
        }
        // Defect(s) Found: 
    }

    private readonly List<int> _queue = new();
    //lista donde se guardan los elementos de la cola 

    /// <summary>
    /// Enqueue the value provided into the queue
    /// </summary>
    /// <param name="value">Integer value to add to the queue</param>
    
    ///Here is the implementation of the Enqueue method but it contains a defect.
    ///
    private void Enqueue(int value) {
       _queue.Add(value);
        //.Add appends the value to the end of the list, which is the correct behavior for a queue.
       // esto significa : “Pon el número al final de la lista”


       // _queue.Insert(0, value);
        //esto dice: Pon el numero en la posicion 0 de la lista y esta mal !
        //the problem with this line is that it inserts the new value at the beginning of the list,
    }
//Pone el numero al inicio pero deberia ponerlo al final para que el primer numero en entrar sea el primero en salir.


    /// <summary>
    /// Dequeue the next value and return it
    /// </summary>
    /// <exception cref="IndexOutOfRangeException">If queue is empty</exception>
    /// <returns>First integer in the queue</returns>
    private int Dequeue() {
        if (_queue.Count <= 0)
            throw new IndexOutOfRangeException();

///Here is  the error in the Dequeue method.
///The problem is that it removes and returns the second element of the list instead of the first
        var value = _queue[0];
        _queue.RemoveAt(0);
        return value;
    }
}