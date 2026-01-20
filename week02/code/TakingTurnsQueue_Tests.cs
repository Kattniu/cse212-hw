using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 1 - Run test cases and record any defects the test code finds in the comment above the test method.
// DO NOT MODIFY THE CODE IN THE TESTS in this file, just the comments above the tests. 
// Fix the code being tested to match requirements and make all tests pass. 

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod] // Es un atributo que indica que el método es una prueba unitaria.
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3) and
    // run until the queue is empty
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
 
    // Defect(s) Found: The logic for re-enqueuing people was flawed. It only re-added 
    // people if turns were greater than 1, but it didn't handle the edge case of 
    // infinite turns (0 or less) properly within the same flow. 
    
    //Este test verifica que la cola funcione correctamente cuando todos tienen turnos limitados.
    public void TestTakingTurnsQueue_FiniteRepetition() //esto es un metodo de prueba unitaria
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3); // se crean 3 objetos person con sus respectivos turnos

        //var -> el compilador infiere el tipo (Person[])
        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim]; //Esto es un arreglo (array) que contiene el orden esperado de las personas al sacar de la cola.

        // Crear la cola y agregar las personas
        var players = new TakingTurnsQueue(); //SE CREA LA COLA QUEUE   
        //Players -> variable 
        //TakingTurnsQueue -> tipo de dato (clase)
        
        players.AddPerson(bob.Name, bob.Turns); //AddPerson es un metodo de la clase TakingTurnsQueue
        players.AddPerson(tim.Name, tim.Turns); // Añaden personas a la cola en este orden:
        players.AddPerson(sue.Name, sue.Turns);// Bob, Tim, Sue

        int i = 0; // es un contador para recorrer el arreglo expectedResult
         // Mientras haya personas en la cola
        while (players.Length > 0)
        {
            // Verificar que no se exceda la longitud del arreglo esperado
            //expectedResult.Length -> longitud del arreglo esperado
            if (i >= expectedResult.Length) //esto evita el bucle infinito
            {
                Assert.Fail("Queue should have ran out of items by now.");// Si se supera la longitud esperada, falla la prueba
            }

            // Obtener la siguiente persona de la cola
            //saca la siguiente persona de la cola
            //GetNextPerson() es un metodo de la clase TakingTurnsQueue
            var person = players.GetNextPerson(); // se obtiene la siguiente persona de la cola
            Assert.AreEqual(expectedResult[i].Name, person.Name); // Compara el nombre de la persona obtenida con el nombre esperado en la posición i del arreglo expectedResult
            i++; // Incrementa el contador i para la siguiente iteración}
        }
    }

    [TestMethod]//-----------------------------------------------------------------------------------------------------------------------
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
    // After running 5 times, add George with 3 turns.  Run until the queue is empty.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
    // Defect(s) Found: Similar to the first test, people were being removed from 
    // the queue prematurely because the condition for re-enqueuing did not 
    // account for the remaining turns correctly.

    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);
        var george = new Person("George", 3);

        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, george, sue, tim, george, tim, george];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        int i = 0;
        for (; i < 5; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        players.AddPerson("George", 3);

        while (players.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);

            i++;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (Forever), Sue (3)
    // Run 10 times.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: People with 0 turns (representing infinite turns) were 
    // not being re-enqueued. The code only checked for person.Turns > 1, 
    // causing "infinite" players to be removed after their first turn.
    public void TestTakingTurnsQueue_ForeverZero()
    {
        var timTurns = 0;

        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", timTurns);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 10; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        // Verify that the people with infinite turns really do have infinite turns.
        var infinitePerson = players.GetNextPerson();
        Assert.AreEqual(timTurns, infinitePerson.Turns, "People with infinite turns should not have their turns parameter modified to a very big number. A very big number is not infinite.");
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Tim (Forever), Sue (3)
    // Run 10 times.
    // Expected Result: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
    // Defect(s) Found: People with negative turns (also representing infinite turns) 
    // were being treated as having no turns left and were removed from the queue 
    // immediately after dequeueing.
    public void TestTakingTurnsQueue_ForeverNegative()
    {
        var timTurns = -3;
        var tim = new Person("Tim", timTurns);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [tim, sue, tim, sue, tim, sue, tim, tim, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 10; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        // Verify that the people with infinite turns really do have infinite turns.
        var infinitePerson = players.GetNextPerson();
        Assert.AreEqual(timTurns, infinitePerson.Turns, "People with infinite turns should not have their turns parameter modified to a very big number. A very big number is not infinite.");
    }

    [TestMethod]
    // Scenario: Try to get the next person from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: None. The exception logic for an empty queue was 
    // correctly implemented with the appropriate error message.
    public void TestTakingTurnsQueue_Empty()
    {
        var players = new TakingTurnsQueue();

        try
        {
            players.GetNextPerson();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("No one in the queue.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}